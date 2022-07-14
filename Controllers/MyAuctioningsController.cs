using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHome.Data;
using AuctionHome.Models;
using Microsoft.AspNetCore.Authorization;
using AuctionHome.Interfaces;
using AuctionHome.Library;

namespace AuctionHome.Controllers
{
    [Authorize]
    public class MyAuctioningsController : Controller
    {
        private readonly IMyAuctioning myAuctioningInterface;
        private readonly IListAuctioning listAuctioningInterface;
        private readonly IItem itemInterface;

        public MyAuctioningsController(IMyAuctioning myAuctioning, IItem itemInterface, IListAuctioning listAuctioning)
        {
            myAuctioningInterface = myAuctioning;
            this.itemInterface = itemInterface;
            this.listAuctioningInterface = listAuctioning;
        }

        private string getUserClaim()
        {

            foreach (var claim in User.Claims)
            {
                var claimType = claim.Type;
                if (claimType == "username") return claim.Value;

            }
            return null;
        }

       
        public async Task<IActionResult> Index()
        {
            
            // get by username;
            var newOject = await myAuctioningInterface.getByUser(getUserClaim());
            return View(newOject);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int idItem)
        {
            
            string idUser = getUserClaim();
            var oldOject = await myAuctioningInterface.getByIdItemAndIdUser(idItem, idUser);
            var oldItem = await itemInterface.getByID(idItem);
            long timeAuction = new TimeToSeconds().getDateTiemToSeconds(await itemInterface.getByID(idItem));
            long _15minutes = 15 * 60;
            if(oldOject != null)
            {
                if(timeAuction > _15minutes)
                {
                    try
                    {

                        
                        // steps 1: remove ID MyAuctioning from array record ListAuctioning;
                        var oldListAuctioning = await listAuctioningInterface.getByID(idItem);
                        var oldMyAuctioning = await myAuctioningInterface.getByIdItemAndIdUser(idItem, getUserClaim());
                        await listAuctioningInterface.removeMyAuctioning(oldListAuctioning, oldMyAuctioning.Id +"");
                        // steps 2: delete row in DB MyAuctioning;
                        await myAuctioningInterface.delete(oldOject);
                        return RedirectToAction("Index", "Items");

                    }
                    catch { return BadRequest(); }
                }
                return Ok("You are not allow cancel this Auction. Because the time of Auction are limit 15 minutes left");

            }
            return Ok("The items is null");

        }

       
    }
}
