using AuctionHome.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionHome.Controllers
{
    public class HandleAuctioningController : Controller
    {
        private readonly IItem itemInterface;
        private readonly IListAuctioning listAuctioningInterface;
        private readonly IMyAuctioning myAuctioningInterface;

        private string getUserClaim()
        {

            foreach (var claim in User.Claims)
            {
                var claimType = claim.Type;
                if (claimType == "username") return claim.Value;

            }
            return null;
        }
        public HandleAuctioningController(IItem item
            , IListAuctioning listAuctioning
            , IMyAuctioning myAuctioning
            )
        {
            this.itemInterface = item;
            this.listAuctioningInterface = listAuctioning;
            this.myAuctioningInterface = myAuctioning;
        }

        [HttpPost]
        public  async Task<IActionResult> AddOrEdit(int idItem, int myMoney)
        {
            //int? idItem, int? myMoney
            //return Ok(myMoney + getUserClaim()+ idItem);
            if (idItem > 0)
            {
                
                var item = await itemInterface.getByID(idItem); // not null
               
                

                

                // test
                
                
                
                
                if (myMoney > item.PriceAuction)
                {
                    // the first, addoredit myautioning
                    var tempMyauctioning = await myAuctioningInterface.getByIdItemAndIdUser(idItem, getUserClaim());
                    if (tempMyauctioning != null)
                    {
                        // update
                        await myAuctioningInterface.updateCost(tempMyauctioning, myMoney);
                    }
                    else
                    {
                        // create 
                        var newMyAuctioning = myAuctioningInterface
                        .new_IdItem_IdUser_Cost(idItem, getUserClaim(), myMoney); // create new object
                        await myAuctioningInterface.create(newMyAuctioning);
                    }

                    // the seconds, addoredit listauctioning
                    // get idMyAuctioning;
                    tempMyauctioning = await myAuctioningInterface.getByIdItemAndIdUser(idItem, getUserClaim());
                    int idMyAuctioning = tempMyauctioning.Id;
                    var newListAuctioning = listAuctioningInterface
                        .newByIdItemAndArrayIdMyAuctioning(idItem, idMyAuctioning + ""); // create new object;
                    await listAuctioningInterface.addOrEdit(newListAuctioning,idMyAuctioning + "");
                    // the third, update price_auction in the Items;
                    var oldItem = await itemInterface.getByID(idItem);
                    await itemInterface.updatePriceAuction(oldItem, (decimal)myMoney);
                }
            }
            return RedirectToAction("Index", "Items");

        }
    }
}
