namespace LimerickStreetArt.Repository
{
	using System;
	using System.Collections.Generic;
	public partial interface UserAccountRepository
	{
		void Create(UserAccount userAccount);
		void Delete(UserAccount userAccount);
		UserAccount GetById(int userAccountId);
		List<UserAccount> GetUserAccounts();
		List<UserAccount> GetActiveUserAccounts();
		void Update(UserAccount userAccount);
	}
}
