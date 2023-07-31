using ShopUku_BAL.Services;
using ShopUku_DAL.Data;
using ShopUku_DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get database
var connection = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.Configure<Connection>(connection);

// AddCors
builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

//

builder.Services.AddSingleton<CartItemRepository>();
builder.Services.AddSingleton<CartItemService>();

builder.Services.AddSingleton<CartRepository>();
builder.Services.AddSingleton<CartService>();

builder.Services.AddSingleton<CategoryRepository>();
builder.Services.AddSingleton<CategoryService>();

builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<CustomerService>();

builder.Services.AddSingleton<FeedbackRepository>();
builder.Services.AddSingleton<FeedbackService>();

builder.Services.AddSingleton<OrderItemRepository>();
builder.Services.AddSingleton<OrderItemService>();

builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<OrderService>();

builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<ProductService>();

builder.Services.AddSingleton<RoleRepository>();
builder.Services.AddSingleton<RoleService>();

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<UserRoleService>();

builder.Services.AddSingleton<UserRoleRepository>();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
