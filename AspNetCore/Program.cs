using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Route Template (Pattern)
// name: "default", // 다수를 설정할 수 있음
// {controller}, {action} : route parameter(꼭 필요한 경우)
// {controller=Home}, {action=Index} : optional route parameter(없으면 기본값)
// {id?} : optional route parameter(없어도 됨)
// 주의!!! : controller와 action은 무조건 정해져야합니다.(매칭or기본값)
// 위에 부터 우선순위

// Constraint (인수 관련)
// {cc: int} 정수만 받음
// {cc: min(18)} 18이상 정수만
// {cc: length(5)} 5글자 string

// 라우팅 패턴 설정
app.MapControllerRoute(
    name: "test",
    pattern: "api/{controller=Home}/{action=Privacy}/{test:int?}")
    .WithStaticAssets();

// Default value와 Constraint를 설정하는 2번째 방법 (Anonymous Object)
app.MapControllerRoute(
    name: "test2",
    pattern: "api/{controller}/{action}/{test:int?}",
    defaults: new {controller ="Home", action="Privacy"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "test3",
    pattern: "api/{test}",
    defaults: new { controller = "Home", action = "Privacy" },
    constraints: new { test= new IntRouteConstraint() })
    .WithStaticAssets();
// Match-All 조커카드
// {*jocker} *을 붙이면 모든 문자열을 다 매칭시킨다.
app.MapControllerRoute(
    name: "test2",
    pattern: "{*jocker}",
    defaults: new { controller = "Home", action = "Privacy" })
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// app.UseWelcomePage();
// app.UseStaticFiles(); // wwwroot의 정적 파일 사용

app.Run();
