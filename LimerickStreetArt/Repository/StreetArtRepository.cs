using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.Repository
{
	public partial interface StreetArtRepository
	{
        StreetArt GetById(int StreetArtId);
        List<StreetArt> GetStreetArtList();
        
        void Delete(StreetArt streetart);
        void Update(StreetArt streetart);
        void Create(StreetArt streetart);
    }
}
