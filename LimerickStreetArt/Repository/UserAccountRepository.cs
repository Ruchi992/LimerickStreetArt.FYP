namespace LimerickStreetArt.Repository
{
    using System;
    using System.Collections.Generic;
    public partial interface UserAccountRepository
    {
        UserAccount Get(int id);
        List<UserAccount> SelectAll();
        List<UserAccount> GetActiveUserAccounts();
        List<UserAccount> Query(Object query);
        void Delete(UserAccount userAccount);
        void Update(UserAccount userAccount);
        void Create(UserAccount userAccount);
    }
}
