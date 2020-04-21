namespace LimerickStreetArt.Repository
{
    using System;

	partial interface UserAccountRepository
    {
        UserAccount GetUserAccountByCredentials(String username, String password);
    }
}