namespace SocialNetworkApp.UnitTests.Fixture
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name = "test 1",
                    Emile = "user1@test",
                    Address = new Address
                    {
                        Street = "street test 1",
                        City = "city test 1",
                        ZipCode = "11111"
                    }
                },
                new User
                {
                    Name = "test 2",
                    Emile = "user2@test",
                    Address = new Address
                    {
                        Street = "street test 2",
                        City = "city test 2",
                        ZipCode = "11112"
                    }
                },
                new User
                {
                    Name = "test 3",
                    Emile = "user3@test",
                    Address = new Address
                    {
                        Street = "street test 3",
                        City = "city test 3",
                        ZipCode = "11113"
                    }
                },
            };


    }
}
