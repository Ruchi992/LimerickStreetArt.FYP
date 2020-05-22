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

			CreateMap<StreetArtModel, StreetArt>()
				.ForMember(
				destination => destination.Image,
				opt => opt.MapFrom(source => source.Image.Name)
				);
			//Todo custom mapping fix
			CreateMap<StreetArt, StreetArtModel>();
			//	.ForMember(
			//	destination => destination.Image.Name,
			//	opt => opt.MapFrom(source => source.Image)
			//	);
		}
	}
}
