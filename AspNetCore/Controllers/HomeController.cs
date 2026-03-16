using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCore.Controllers
{
    // Model : 메모리, 파일, DB 등 정보 추출
    // Controller : 데이터 가공, 필터링, 유효성 체크, 서비스 호출 등
    // + 각종 서비스
    // View : 최종 결과물

    // MVC에서 Controller는 가공을 담당
    // 데이터를 넘길때, IActionResult를 넘김
    /** 자주 사용되는 IActionResult 종류
     * 1) ViewResult : HTML view생성
     * 2) RedirectResult : 요청을 다른 곳으로 전환
     * 3) FileResult : 파일 반환
     * 4) ContentResult : 특정 string 반환
     * 5) StatusCodeResult : HTTP status code 반환
     * 6) NotFoundResult : 404 HTTP status code 반환
     * **/

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Data From Privacy";
            return View();
        }

        //[Route("Hello")] // 라우트 추가 "/Hello"
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
