using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OCMAdmin.Models;

[assembly: HostingStartup(typeof(OCMAdmin.Areas.Identity.IdentityHostingStartup))]
namespace OCMAdmin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OCMAdminContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OCMAdminContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<OCMAdminContext>();
            });
        }
    }
}