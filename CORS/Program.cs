var builder = WebApplication.CreateBuilder(args);

/*
 * Ana Domain						Origin								Sonu�
 * https://www.contoso.com	https://www.contoso.com/page/3				Ba�ar�l� bir istek (Protokol ve Host ayn�)
 *							https://www.contoso.com/images/upload.png	Ba�ar�l� bir istek (Protokol ve Host ayn�)
 *							https://www.contoso.com:88					Ba�ar�s�z bir istek (Protokol ve Host ayn� ama Port farkl�)	
 *							http://www.contoso.com						Ba�ar�s�z bir istek (Host ve Port ayn� ama Protokol farkl�)
 */

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(); // Domainden gelen taleplere izin vermek i�in
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

//app.UseCors(); // Domainden gelen taleplere izin vermek i�in
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors("ClientDomains"); // Veya buray� kapat. Parametresiz halini a�. Controllerda methoda veya class yukar�s�na annotation olarak [EnableCors("ClientDomains")] ekle. Mesele controller seviyesinde a�t�n bir methodda kapatmak i�in o methoda [DisableCors] ekle

app.MapControllers();

app.Run();
