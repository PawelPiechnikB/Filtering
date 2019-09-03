// sample.TissueType.Name.Contains("xxx")
class FilterElement
{
    public string Property { get;set; }

    public object Value { get; set; }

    public FilteringOperator Operator { get; set; }

    public Expresion CreateExpresion()
    {
    }
}

class FilterCollection
{
    public IList<FilterElement> Elements { get; set; } 

    public FilterCollectionOperator Operator { get; set; } 

    public Expresion CreateExpresion()
    {
    }
}

public enum FilterCollectionOperator
{
    And,
    Or
}

public enum FilteringOperator
{
    Equals,
    NotEquals,
    Contains
}
