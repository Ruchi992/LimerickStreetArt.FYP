namespace LimerickStreetArt.Repository
{
    using System;
    using System.Collections.Generic;
    public partial interface UserAccountRepository
    {
        UserAccount GetById(int userAccountId);
        List<UserAccount> GetUserAccounts();
        List<UserAccount> GetActiveUserAccounts();
        void Delete(UserAccount userAccount);
        void Update(UserAccount userAccount);
        void Create(UserAccount userAccount);
    }
}
