var builder = WebApplication.CreateBuilder(args);

/*
 * Ana Domain						Origin								Sonuç
 * https://www.contoso.com	https://www.contoso.com/page/3				Baþarýlý bir istek (Protokol ve Host ayný)
 *							https://www.contoso.com/images/upload.png	Baþarýlý bir istek (Protokol ve Host ayný)
 *							https://www.contoso.com:88					Baþarýsýz bir istek (Protokol ve Host ayný ama Port farklý)	
 *							http://www.contoso.com						Baþarýsýz bir istek (Host ve Port ayný ama Protokol farklý)
 */

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(); // Domainden gelen taleplere izin vermek için
builder.Services.AddCors(x => x.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
//builder.Services.AddCors(x => x.AddPolicy("ClientDomains", x => x.WithOrigins("www.contoso.com", "www.test.com").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors(); // Domainden gelen taleplere izin vermek için
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors("ClientDomains"); // Veya burayý kapat. Parametresiz halini aç. Controllerda methoda veya class yukarýsýna annotation olarak [EnableCors("ClientDomains")] ekle. Mesele controller seviyesinde açtýn bir methodda kapatmak için o methoda [DisableCors] ekle

app.MapControllers();

app.Run();
