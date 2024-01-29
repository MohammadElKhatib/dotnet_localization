using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Localization.Localization
{
    public static class DependencyInjection
	{
		public static void AddLocalizationServices(this IServiceCollection services)
		{
			services.AddLocalization(options => options.ResourcesPath = "Resources");

			services.AddMvc()
				.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
				.AddDataAnnotationsLocalization();

			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[] { "en", "ar" };

				options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());

				options.SetDefaultCulture(supportedCultures.First())
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);
			});
		}

		public static void AddLocalizationMiddleware(this WebApplication app)
		{
			app.UseRequestLocalization();
		}
	}
}

