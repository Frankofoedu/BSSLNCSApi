using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSSLNCSApi.Controllers
{
    public class RevenueViewModel
    {
        public string MainCatCode { get; set; }
        public string MainCatDesc { get; set; }
        public List<RevenueSubCategory> SubCategories { get; set; }
    }

    public class RevenueSubCategory
    {
        public string RevCode { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatDesc { get; set; }
        public decimal? Rate { get; set; }
        public string FrequencyOfPay { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {

        private readonly dc_ncsContext context;

        public RevenueController(dc_ncsContext _context)
        {
            context = _context;
        }


        /// <summary>
        /// To get list of all revenue categories
        /// </summary>
        /// <returns>List of Main category and a list of subcategories under the main category with rates</returns>
        [HttpGet("GetRevenueCategories")]
        public IActionResult GetCat()
        {
            try
            {
                var data = new Dictionary<string, RevenueViewModel>();

                var subCa = context.Revenue;

                var subCats = subCa.ToList();

                foreach (var subCat in subCats)
                {
                    if (!data.ContainsKey(subCat.Category))
                    {
                        var mCat = context.Revenuecat.FirstOrDefault(x => x.Catcode == subCat.Category);

                        if (mCat != null)
                        {

                            data.Add(subCat.Category, new RevenueViewModel
                            {

                                MainCatCode = subCat.Category,
                                MainCatDesc = mCat.Catrevdesc,
                                SubCategories = new List<RevenueSubCategory> {
                                new RevenueSubCategory { 
                                     RevCode = $"{subCat.Subcode}{subCat.Revcode}",
                                    Rate = subCat.Revenuerate,
                                    SubCatCode = subCat.Subcode,
                                    SubCatDesc = subCat.Revdesc, 
                                    FrequencyOfPay = subCat.FreqPay

                                }
                                }
                            });
                        }


                    }
                    else
                    {
                        data[subCat.Category].SubCategories.Add(
                          new RevenueSubCategory
                          {
                              RevCode = $"{subCat.Subcode}{subCat.Revcode}",
                              Rate = subCat.Revenuerate,
                              SubCatCode = subCat.Subcode,
                              SubCatDesc = subCat.Revdesc
                          }
                        );
                    }
                }

                return Ok(data.Values.ToList());
            }
            catch (NullReferenceException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}