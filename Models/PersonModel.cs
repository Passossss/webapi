class PersonModel
{
    public int Id { get; private set; }
    public string Name { get; set; }

    public static PersonModel(string name)
    {
        name = this.Name;

    }
}