using Microsoft.AspNetCore.Builder;
using VumbaSoft.AdventureWorksAbp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AdventureWorksAbpWebTestModule>();

public partial class Program
{
}
