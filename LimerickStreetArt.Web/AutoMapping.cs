namespace LimerickStreetArt.Web
{
	using AutoMapper;
	using LimerickStreetArt.Web.Models;

	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			//
			//	UserAccountModel
			//
			CreateMap<UserAccountModel, UserAccount>();
			CreateMap<UserAccount, UserAccountModel>();
			//
			//	StreetArtModel
			//
			CreateMap<StreetArtModel, StreetArt>();
			CreateMap<StreetArt, StreetArtModel>();
			//
			//	StreetArtEditModel
			//
			CreateMap<StreetArtEditModel, StreetArt>();

			CreateMap<StreetArt, StreetArtEditModel>();
		}
	}
}
