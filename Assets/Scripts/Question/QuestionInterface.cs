public interface CountryQuestion
{
    string name { get; set; }

    string userAnswer { get; set; }

    bool Completed { get; set; }
    bool CheckIfRight(string Answer);
}