using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHome.Data;
using AuctionHome.Models;
using AuctionHome.Interfaces;
using AuctionHome.Library;
using Microsoft.AspNetCore.Authorization;

namespace AuctionHome.Controllers
{
    [Authorize]
    public class PaidItemsController : Controller
    {
        private readonly IPaidItems paidItemsInterface;
        private readonly IItem itemInterface;
        private readonly IListAuctioning listAuctioningInterface;
        private readonly IMyAuctioning myAuctioningInterface;
        public PaidItemsController(IPaidItems paidItems, IItem item, IListAuctioning listAuctioning, IMyAuctioning myAuctioning)
        {
            this.paidItemsInterface = paidItems;
            itemInterface = item;
            listAuctioningInterface = listAuctioning;
            myAuctioningInterface = myAuctioning;

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
        [HttpPost]
        public async Task<IActionResult> BuyNow(int idItem)
        {
            // set old Item;
            // price buy now >0
            // cancel auction (set time auction to date now)
            // create PaidItem
            // update Item is sold
            
            // steps 1;
            var oldItem = await itemInterface.getByIDAsync(idItem);
            if (oldItem != null)
            {
                // steps 2:
                if(oldItem.PriceBuyNow>0)
                {
                    // steps 3:
                    // steps 00.1;
                    var listAuctioningCurrent = await listAuctioningInterface.getByID(idItem);
                    var arrLIdMyAuc = new List<string>();
                    if (listAuctioningCurrent != null)
                    {
                        arrLIdMyAuc = new ConvertStringAndList()
                        .stringToList(listAuctioningCurrent.ArrayIdMyAuctioningString);
                    }
                    // steps 0.1;
                    foreach (var eachMy in arrLIdMyAuc)
                    {
                        var mimi = await myAuctioningInterface.getByID(Int32.Parse(eachMy));

                        await myAuctioningInterface.delete(mimi);
                    }
                    // steps 0.2;
                    await listAuctioningInterface.delete(listAuctioningCurrent);
                    // steps 0.3:
                    await itemInterface.updateTimeAuction(oldItem, DateTime.Now);

                    // steps 4;
                    var paidItem = new PaidItem();
                    paidItem.IdItems = idItem;
                    paidItem.IdUser = getUserClaim();
                    paidItem.Coust = oldItem.PriceBuyNow;
                    await paidItemsInterface.update(paidItem);
                    // steps 5;
                    await itemInterface.setSold(oldItem);
                    return RedirectToAction("Index", "PaidItems");
                }
            }
            return Ok("something wrong");
          
        }
        public async Task<IActionResult> Index()
        {
            // get item by username;
            var arrList =  await paidItemsInterface.getByUsername(getUserClaim());
            return View(arrList);
        }

    }
}
