using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Share.DTO;

namespace Client.Pages.ForgetPassword
{
    public class ConfirmAccountModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public ConfirmAccountModel(ICustomHttpClient request)
        {
            _request = request;
        }

       
    }
}
