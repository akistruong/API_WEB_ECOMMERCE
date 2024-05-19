using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Models.ParamModels;
using API_DSCS2_WEBBANGIAY.Utils;
using API_DSCS2_WEBBANGIAY.Utils.Mail;
using API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_DSCS2_WEBBANGIAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {

        private readonly ShoesEcommereContext _context;
        private readonly IMailService mailService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<MailSettings> mailSettings;
        private readonly IHostingEnvironment _HostEnvironment;

        public HoaDonController(ShoesEcommereContext context, IMailService mailService, IConfiguration configuration, IOptions<MailSettings> mailSettings,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.mailService = mailService;
            _configuration = configuration;
            this.mailSettings = mailSettings;
            this._HostEnvironment = hostingEnvironment;
        }

        private async Task<IActionResult> VNPAY(PhieuNhapXuat HoaDon)
        {
            
            //Get Config Info
            string vnp_Returnurl = _configuration["VNPAYConfigs:vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = _configuration["VNPAYConfigs:vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _configuration["VNPAYConfigs:vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = _configuration["VNPAYConfigs:vnp_HashSecret"]; //Chuoi bi mat
            if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
            {
                //lblMessage.Text = "Vui lòng cấu hình các tham số: vnp_TmnCode,vnp_HashSecret trong file web.config";
                //return;
            }
            //Get payment input
            VNPay vnpay = new VNPay();
            vnpay.AddRequestData("vnp_Version", VNPay.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (HoaDon.ThanhTien * 100).ToString());
            //vnpay.AddRequestData("vnp_BankCode", body.BankCode?? "NCB");
            vnpay.AddRequestData("vnp_CreateDate", HoaDon.createdAt.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            var ipAddressParams = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");
            var remote_ADDR = HttpContext.GetServerVariable("REMOTE_ADDR"); ;
            vnpay.AddRequestData("vnp_IpAddr", Utils.Utils.GetIpAddress(ipAddressParams, remote_ADDR));
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + HoaDon.Id);
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", HoaDon.Id.ToString());
            //Add Params of 2.1.0 Version
            //vnpay.AddRequestData("vnp_ExpireDate", txtExpire.Text);
            //info
            vnpay.AddRequestData("vnp_Bill_Mobile", HoaDon.DiaChiNavigation?.Phone?.Trim());
            vnpay.AddRequestData("vnp_Bill_Email", HoaDon.DiaChiNavigation?.Email?.Trim());
            vnpay.AddRequestData("vnp_Bill_Address", $"({HoaDon?.DiaChiNavigation?.AddressDsc}), {HoaDon.DiaChiNavigation.WardName}, {HoaDon.DiaChiNavigation.DistrictName}, {HoaDon.DiaChiNavigation.ProvinceName}");
            vnpay.AddRequestData("vnp_Bill_City", HoaDon?.DiaChiNavigation?.ProvinceID?.ToString());
            vnpay.AddRequestData("vnp_Bill_Country", HoaDon.DiaChiNavigation.DistrictID.ToString());
            vnpay.AddRequestData("vnp_Bill_State", HoaDon.DiaChiNavigation.WardID.ToString());
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return Ok(new
            {
                redirect=paymentUrl,
            });
        }
        [HttpGet("GetOrderByID/{id}")]
        public async Task<IActionResult>GetOrderByID(int id)
        {
            try
            {
                var order = _context.PhieuNhapXuats.Include(x=>x.ChiTietNhapXuats).ThenInclude(x=>x.SanPhamNavigation).Include(x=>x.DiaChiNavigation).FirstOrDefault(x => x.Id == id);
                return order is not null ? Ok(order) : NotFound();
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
        private bool CheckQTY(PhieuNhapXuat body)
        {
            try
            {
                foreach(var k in body.ChiTietNhapXuats)
                {
                    var kh = _context.KhoHangs.FirstOrDefault(x => x.MaSanPham == k.MaSanPham && x.MaChiNhanh == body.MaChiNhanh);
                    if(kh != null)
                    {
                        if(kh.SoLuongTon-k.SoLuong<0||kh.SoLuongCoTheban-k.SoLuong<0)
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }catch(Exception err)
            {
                return false;
            }
        }
        [HttpGet("Coupon")]
        public async Task<IActionResult> GetCoupons()
        {
            try
            {
                var coupons = _context.Coupons;
                return Ok(coupons);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
        private bool checkNhomDoiTuong(Models.Coupon coupon,PhieuNhapXuat body)
        {
            var doituong = coupon.NhomDoiTuong;
            if(doituong ==1)
            {
                return true;
            }
            else if (doituong==2)
            {
                if(body.idTaiKhoan==null) return false;
                var user = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan.Trim() == body.idTaiKhoan.Trim());
                if (user is null) return false;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkDieuKien(Models.Coupon coupon, PhieuNhapXuat body)
        {
            if(body.ThanhTien<coupon.GiaTriDonHangToiThieu)
            {
                return false;
            }
            if(body.TongSoLuong<coupon.SoLuongSPToiThieu)
            {
                return false;
            }
            if (coupon.SoLuong <= 0)
            {
                return false;
            }
            return true;
        }
        [HttpPost("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(PhieuNhapXuat body)
        {
            var couponCode = body.CouponCode;
            if (couponCode == null) return BadRequest();
            var coupon = _context.Coupons.Include(x=>x.ChiTietCoupons).FirstOrDefault(x => x.MaCoupon.Trim() == couponCode.Trim());
            if (coupon == null) return NotFound();
            if (coupon.NgayKetThuc <= DateTime.Now ) return BadRequest("Coupon đã hết hạn");
            if (!coupon.trangThai) return BadRequest("Coupon không khả dụng");
            if(coupon.MaChiNhanh is not null && coupon.MaChiNhanh.Length>0)
            {
                if(coupon.MaChiNhanh.Trim() != body.MaChiNhanh.Trim())
                {
                    return BadRequest("Coupon không khả dụng tại chi nhánh này");
                }
            }
            if (checkDieuKien(coupon,body)&&checkNhomDoiTuong(coupon,body))
            {
                body.CouponNavigation = coupon;
                if(coupon.LoaiKhuyenMai==1)
                {
                    var tienGiam = (coupon.GiaTri * body.ThanhTien) / 100;
                    body.TienDaGiam = tienGiam ;
                    body.ThanhTien -= tienGiam;
                }
                else if(coupon.LoaiKhuyenMai==2)
                {
                    var tienGiam = coupon.GiaTri ;
                    body.TienDaGiam = tienGiam ;
                    body.ThanhTien -= tienGiam;
                }
                else
                {

                }
                return Ok(body);
            }
            else
            {
                return BadRequest("Mã không hợp lệ");
            }
        }
        [HttpGet("VNPAY_RETURN")]
        public async Task<IActionResult> VNPAY_RETURN()
        {
            var vnpayData = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            string vnp_HashSecret = _configuration["VNPAYConfigs:vnp_HashSecret"]; //Chuoi bi mat
            VNPay vnpay = new VNPay();
            foreach (string s in vnpayData)
            {
                //get all querystring data
                if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(s, vnpayData[s]);
                }
            }
            long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
            long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
            String vnp_SecureHash = vnpayData["vnp_SecureHash"];
            String TerminalID = vnpayData["vnp_TmnCode"];
            long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
            String bankCode = vnpayData["vnp_BankCode"];
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
            if (checkSignature)
            {
                var hd = _context.PhieuNhapXuats.FirstOrDefault(x => x.Id == orderId);
                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    //hd.status = 1;
                    //if(hd.idTaiKhoan is not null)
                    //{
                    //    var tk = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan == hd.idTaiKhoan);
                    //    if(tk is not null)
                    //    {
                    //        tk.TienThanhToan += hd.ThanhTien;
                    //        tk.SoLanMuaHang++;
                    //        _context.Entry(tk).State = EntityState.Modified;
                    //    }
                    //}
                    //_context.PhieuNhapXuats.Update(hd);
                    var ClientURL = _configuration.GetSection("ClientURL").Value;
                    var token = JWTHandler.Generate(DateTime.Now.AddDays(1));
                    await _context.SaveChangesAsync();
                    return Redirect($"{ClientURL}/orderStatus/{hd.Id}/{token}");
                }
                else
                {
                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                    _context.PhieuNhapXuats.Remove(hd);
                    var ClientURL = _configuration.GetSection("ClientURL").Value;
                    await _context.SaveChangesAsync();
                    var token = JWTHandler.Generate(DateTime.Now.AddDays(1));

                    return Redirect($"{ClientURL}/orderStatus/{hd.Id}/{token}");
                }
            }
                return Ok();
        }
        private PhieuNhapXuat order(PhieuNhapXuat body)
        {
            try
            {
                body.steps = 1;
                foreach (var item in body.ChiTietNhapXuats)
                {
                    if(item.SoLuong<=0)
                    {
                        return null;
                    }
                    _context.Entry(item).State = EntityState.Added;

                }

                _context.Entry(body).State = EntityState.Added;
                if(body.IdDiaChi is  null)
                {
                    _context.Entry(body.DiaChiNavigation).State = EntityState.Added;
                }
                else
                {
                    var dc = _context.DiaChis.FirstOrDefault(x => x.ID == body.IdDiaChi);
                    if (dc is not null) body.DiaChiNavigation = dc;

                }
                _context.SaveChanges();
                return body;
            }
            catch (Exception ex)
            {
                return null ;
            }
        }
        [HttpPost("OrderWithCOD")]
        public async Task<IActionResult> OrderWithCOD(PhieuNhapXuat body)
        {
            try
            {
                if(body.ChiTietNhapXuats.Count<=0)
                {
                    return BadRequest();
                }
                if (CheckQTY(body) == false)
                {
                    return BadRequest("Số lượng trong kho không cho phép");
                }
                body.PhuongThucThanhToan = "COD";
                var res = order(body);
                var bodyString = await new Confirm(_HostEnvironment, body).RenderBody();
                var mailBody = new MailRequest()
                {
                    Body = bodyString.ToString(),
                    Subject = "XÁC NHẬN ĐƠN HÀNG",
                    ToEmail = body.DiaChiNavigation?.Email,
                };
                var mailSend = new MailService(mailSettings);
                mailSend.SendEmailAsync(mailBody);

                return Ok(body);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("OrderWithVNPAY")]
        public async Task<IActionResult> OrderWithVNPAY(PhieuNhapXuat body)
        {
            try
            {
                if (body.ChiTietNhapXuats.Count <= 0)
                {
                    return BadRequest();
                }
                if (CheckQTY(body) == false)
                {
                    return BadRequest("Số lượng trong kho không cho phép");
                }
                body.PhuongThucThanhToan = "VNPAY";
                var hoadon = order(body);
                var bodyString = await new Confirm(_HostEnvironment, body).RenderBody();
                var mailBody = new MailRequest()
                {
                    Body = bodyString.ToString(),
                    Subject = "XÁC NHẬN ĐƠN HÀNG",
                    ToEmail = body.DiaChiNavigation?.Email,
                };
                var mailSend = new MailService(mailSettings);
                mailSend.SendEmailAsync(mailBody);
                if (hoadon == null) return BadRequest();
                return await VNPAY(hoadon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("UpdateProductOrder/{id}")]
        public async Task<IActionResult> UpdateProductOrder(PhieuNhapXuat body)
        {
            try
            {
                _context.PhieuNhapXuats.Update(body);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [HttpPost("CheckStatusOrder/{orderID}")]
        public async Task<IActionResult> CheckStatusOrder( TokenParams  token,int orderID)
        {
            try
            {
                var validToken = JWTHandler.VerifyToken(token.token);
                if (!validToken) return BadRequest();
                var order = _context.PhieuNhapXuats.Include(x=>x.ChiTietNhapXuats).ThenInclude(x=>x.SanPhamNavigation).FirstOrDefault(x => x.Id == orderID);
                if (order == null) return NotFound("Không tìm thấy đơn hàng này");
                return Ok(order);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpGet("/StripeSuccess/{id}")]
        public async Task<IActionResult> StripeSuccess(int id)
        {
            try
            {
                var hd = _context.PhieuNhapXuats.Include(x=>x.DiaChiNavigation).FirstOrDefault(x => x.Id == id);
                if (hd == null) return NotFound();
                var bodyString = await new Confirm(_HostEnvironment, hd).RenderBody();
                var mailBody = new MailRequest()
                {
                    Body = bodyString.ToString(),
                    Subject = "XÁC NHẬN ĐƠN HÀNG",
                    ToEmail = hd.DiaChiNavigation?.Email,
                };
                var mailSend = new MailService(mailSettings);
                mailSend.SendEmailAsync(mailBody);
                var ClientURL = _configuration.GetSection("ClientURL").Value;
                var token = JWTHandler.Generate(DateTime.Now.AddDays(1));
                return Redirect($"{ClientURL}/orderStatus/{hd.Id}/{token}");
            }
            catch(Exception err)
            {
                return BadRequest();
            }
            
        }
        [HttpGet("/StripeCancel/{id}")]
        public async Task<IActionResult> StripeCancel(int id)
        {
            try
            {
                var hd = _context.PhieuNhapXuats.FirstOrDefault(x => x.Id == id);
                if (hd == null) return NotFound();
                _context.PhieuNhapXuats.Remove(hd);
                _context.SaveChanges();
                var ClientURL = _configuration.GetSection("ClientURL").Value;
                var token = JWTHandler.Generate(DateTime.Now.AddDays(1));
                return Redirect($"{ClientURL}/orderStatus/{hd.Id}/{token}");
            }
            catch(Exception err)
            {
                return BadRequest();
            }
        }

        [HttpPost("StripePayment")]
        public async Task<IActionResult> OrderWithStripe(PhieuNhapXuat body)
        {
            try
            {
                if (body.ChiTietNhapXuats.Count <= 0)
                {
                    return BadRequest();
                }
                if (CheckQTY(body) == false)
                {
                    return BadRequest("Số lượng trong kho không cho phép");
                }
                body.PhuongThucThanhToan = "PAYPAL";
                var hoadon = order(body);
                if (hoadon == null) return BadRequest();
                return CreateSessionStripePayment(hoadon);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
        private IActionResult CreateSessionStripePayment(PhieuNhapXuat body)
        {
            try
            {
                StripeConfiguration.ApiKey = _configuration["StripeKey:SecretKey"];
                var domain = _configuration["BaseURL"];
                var items = new List<SessionLineItemOptions>();
                var prices = Convert.ToInt32(body.ThanhTien);
                    if (body.ChiTietNhapXuats.Count < 0) return BadRequest();
                var options = new Stripe.Checkout.SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = Convert.ToInt32(body.ThanhTien),
                                Currency = "vnd",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Checkout for order #" + body.Id
                                }
                            },
                            
                            Quantity = body.TongSoLuong
                        }
                    },
                    Mode = "payment",
                    SuccessUrl = domain + "StripeSuccess/" + body.Id,
                    CancelUrl = domain + "StripeCancel/" + body.Id,
                    CustomerEmail = body.DiaChiNavigation.Email.Trim(),
                     
                    InvoiceCreation = new SessionInvoiceCreationOptions
                    {
                        Enabled = true
                    }
                };
                //var invoice = 
                var service = new Stripe.Checkout.SessionService();
                Stripe.Checkout.Session session = service.Create(options);
                return Ok(session.Url);
            }catch(Exception err)
            {
                return BadRequest();
            }
        }
    }
}
