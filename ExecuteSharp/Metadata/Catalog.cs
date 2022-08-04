namespace ExecuteSharp.Metadata
{
    public abstract class Catalog : NamedMetadata
    {
        public Catalog(string name) : base(name)
        {
            Name = name;
        }

        public List<Schema> Schemas { get; set; } = new();
        public List<Table> Tables { get; set; } = new ();
        public List<View> Views { get; set; } = new ();
        public List<Synonym> Synonyms { get; set; } = new();
        public List<StoredProcedure> StoredProcedures { get; set; } = new ();
        public List<Function> Functions { get; set; } = new();
    }
}