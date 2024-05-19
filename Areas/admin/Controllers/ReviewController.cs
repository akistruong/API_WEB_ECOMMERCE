using API_DSCS2_WEBBANGIAY.Models;
using API_DSCS2_WEBBANGIAY.Models.ParamModels;
using API_DSCS2_WEBBANGIAY.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ShoesEcommereContext _context;

        public ReviewController(ShoesEcommereContext context)
        {
            _context = context;
        }
        [HttpPost("{orderID}")]
        public IActionResult GetOrderRating(int orderID,TokenParams token)
        {
            try
            {
                var validToken = JWTHandler.VerifyToken(token.token);
                var order = _context.PhieuNhapXuats.Include(x => x.ChiTietNhapXuats).ThenInclude(x=>x.SanPhamNavigation).FirstOrDefault(x => x.Id == orderID);
                if (order == null) return NotFound("Không tìm thấy đơn hàng này");
                if ((bool)order.DaReview) return BadRequest("Đã đánh giá đơn hàng này");
                return Ok(order);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [HttpPost()]
        public IActionResult AddProductRating(List<StarReviewDetail> body)
        {
            try
            {
                List<ReviewStar> tempArr = new List<ReviewStar>();
                foreach (var x in body)
                {
                    var product = _context.SanPhams.Include(t => t.StarReviewNavigation).FirstOrDefault(g => g.MaSanPham.Trim() == x.MaSanPham.Trim());

                    if (product is null) return NotFound();
                    var Star = product.StarReviewNavigation;


                    switch (x.Rating)
                    {
                        case 1:
                            Star.MotSao++;
                            break;
                        case 2:
                            Star.HaiSao++;
                            break;
                        case 3:
                            Star.BaSao++;
                            break;
                        case 4:
                            Star.BonSao++;
                            break;
                        case 5:
                            Star.NamSao++;
                            break;
                        default:
                            return BadRequest("Invalid rating value.");
                    }
                    if (Star != null)
                    {
                        if (tempArr.Count() <= 0)
                        {
                            Star.total++;
                            Star.Avr = (Star.MotSao + Star.HaiSao * 2 + Star.BaSao * 3 + Star.BonSao * 4 + Star.NamSao * 5) / (double)Star.total;
                            tempArr.Add(Star);
                        }
                        else
                        {
                            var check = tempArr.Any(x => x.Id == Star.Id);
                            if (check)
                            {
                                var obj = tempArr.FirstOrDefault(x => x.Id == Star.Id);
                                if (obj is not null)
                                {
                                    var index = tempArr.IndexOf(obj);
                                    if (index > -1)
                                    {
                                        tempArr[index].total++;
                                        tempArr[index].Avr = (Star.MotSao + Star.HaiSao * 2 + Star.BaSao * 3 + Star.BonSao * 4 + Star.NamSao * 5) / (double)Star.total;
                                    }
                                }
                                else
                                {
                                    return BadRequest();
                                }
                            }
                            else
                            {
                                Star.total++;
                                Star.Avr = (Star.MotSao + Star.HaiSao * 2 + Star.BaSao * 3 + Star.BonSao * 4 + Star.NamSao * 5) / (double)Star.total;
                                tempArr.Add(Star);
                            }
                        }

                        x.StarReviewID = (int)product.ReviewID;
                        _context.Entry(x).State = EntityState.Added;
                    }
                }
                var order = _context.PhieuNhapXuats.FirstOrDefault(t => t.Id == body[0].IDDonHang);
                order.DaReview = true;
                _context.Entry(order).State = EntityState.Modified;
                foreach (var star in tempArr)
                {
                    _context.Entry(star).State = EntityState.Modified; 
                }
                _context.SaveChanges();
                return Ok(body);
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
    }
    }
