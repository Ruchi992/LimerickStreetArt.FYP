namespace LimerickStreetArt.Repository
{
    using System;

	public partial interface UserAccountRepository
    {
        UserAccount GetUserAccountByCredentials(String username, String password);
    }
}
