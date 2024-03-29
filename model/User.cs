﻿namespace MarkEdPlace.model
{
    internal class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Product> ProductsInCart { get; set; }

        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
