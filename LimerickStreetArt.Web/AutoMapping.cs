namespace LimerickStreetArt.Web
{
	using AutoMapper;
	using LimerickStreetArt.Web.Models;

	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<UserAccountModel, UserAccount>();
			CreateMap<UserAccount, UserAccountModel>();

			//CreateMap<UserAccountModel, UserAccount>();

		}
	}
}
