using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace authpark.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        //public ActionResult PaymentWithPaypal()
        //{
        //    APIContext apiContext = PaypalConfiguration.GetAPIContext();
        //    try
        //    {
        //        string payerId = Request.Params["PayerID"];
        //        if (string.IsNullOrEmpty(payerId))
        //        {
        //            string baseUri = Request.Url.Scheme + "://" + Request.Url.Authority + "PaymentWithPaypal?";
        //            var Guid = Convert.ToString((new Random()).Next(100000000));
        //            var createPayment = this.createPayment(apiContext, baseUri + "guid=" + Guid);
        //            var links = createPayment.links.GetEnumerator();
        //            string paypalRedirectURL = null;
        //            while (links.MoveNext())
        //            {
        //                Links lnk = links.Current;
        //                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
        //                {
        //                    paypalRedirectURL = lnk.href;
        //                }
        //                else
        //                {
        //                    var guid = Request.Params["guid"];
        //                    var executepayment = ExecutePayment(apiContext, payerId,Session["guid"] as string);
        //                    if (executepayment.ToString().ToLower()!="approved")
        //                    {
        //                        return View("FaliureView");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private object ExecutePayment(APIContext apiContext, string payerId, string PaymentId)
        {
            var paymentExecution = new PaymentExecution() {payer_id=payerId };
            this.payment = new Payment() { id = PaymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private PayPal.Api.Payment payment;
        private Payment createPayment(APIContext apiContext, string redirectURL)
        {
            var ItemLIst = new ItemList() { items=new List<Item>()};
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)(Session["cart"]); 
            foreach (var item in (List<Item>)Session["cart"])
            {
                item.name.ToString();
                item.currency = "USD";
                item.price.ToString();
                item.quantity.ToString();
                item.sku = "sku";
            }
            }
            var payer = new Payer() { payment_method = "paypal" };
            var redirectUrl = new RedirectUrls()
            {
                cancel_url = redirectURL + "&cancel=true",
                return_url = redirectURL
            };
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };
            var amount = new Amount()
            {
                currency = "USD",
                total = Session["Total"].ToString(),
            details = details,
            };
            var tranactionList = new List<Transaction>();
            tranactionList.Add(new Transaction() {
            description="Transaction Description",
            invoice_number="#1000000",
            amount=amount,
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = tranactionList,
                redirect_urls = redirectUrl,

            };
            return payment.Create(apiContext);
        }
        
    }
}