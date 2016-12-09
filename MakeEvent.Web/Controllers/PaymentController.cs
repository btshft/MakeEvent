using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MakeEvent.Web.Attributes;
using MakeEvent.Web.Helpers;
using MakeEvent.Web.Models.Yandex;
using MakeEvent.Web.Settings;

namespace MakeEvent.Web.Controllers
{
    [RequireHttps, HandleMvcException, Localized]
    public class PaymentController : BaseController
    {
        [HttpPost]
        public ActionResult Pay(YandexPaymentNotificationModel payment)
        {
            var inputArgs = $"{payment.notification_type}&{payment.operation_id}&{payment.amount}&" +
                            $"{payment.currency}&{payment.datetime}&{payment.sender}&{payment.codepro.ToString().ToLower()}&" +
                            $"{YandexWallet.Secret}&{payment.label}";

            var inputSha1 = HashHelper.GetSha1Hash(inputArgs);

            if (string.Equals(inputSha1, payment.sha1_hash, StringComparison.OrdinalIgnoreCase))
            {
                
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public ActionResult Pay()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}