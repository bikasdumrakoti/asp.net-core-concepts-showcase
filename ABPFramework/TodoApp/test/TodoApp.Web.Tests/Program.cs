using Microsoft.AspNetCore.Builder;
using TodoApp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<TodoAppWebTestModule>();

public partial class Program
{
}
