namespace LimerickStreetArt.Repository
{
    using System;

    partial interface UserAccountRepository
    {
        UserAccount Login(String username, String password);
    }
}
