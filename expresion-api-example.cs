namespace ConsoleApp1
{

    class TissueSample
    {
        public TissueType TissueType { get; set; }
        public ICollection<TissueType> TissueTypes { get; set; }
        public int Count { get; set; }
    }

    class TissueType
    {
        public string Name { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // potrzebujemy znać encję którą filtrujemy
            // potrzebujemy znać scieżek do pól filtrowanych
            // potrzebujemy znać wartości do filtrowania
            // potrzebujemy w łatwy sposób ustalić jaki jest prawdiłowy operator do filtrowania danego pola


            // sample.TissueType.Name

            // sample
            var parameterExpression = Expression.Parameter(typeof(TissueSample), "sample");

            // sample.TissueType
            var memberExpression = Expression.Property(parameterExpression, nameof(TissueSample.TissueType));

            // sample.TissueType.Name
            var expression = Expression.Property(memberExpression, nameof(TissueType.Name));

            // sample.TissueType.Name.Contains("xxx")
            var method = GetContainsMethod(expression);
            var methodCallExpression = Expression.Call(expression, method, Expression.Constant("xxx"));

            // sample => sample.TissueType.Name.Contains("xxx")
            // sample => sample.TissueType.Name.ToLower().Trim().Contains("xxx".ToLower().Trim())
            // sample => sample.TissueType.Name = "xxx"
            var condition = Expression.Lambda<Func<TissueSample, bool>>(methodCallExpression, parameterExpression);

            // sample => sample.TissueType.Name.Contains("xxx") || sample.Fixative.Name.Contains("yyy")
            // Expression.Or() lub Expression.Or()

            // sample => sample.TissueTypes.Any(type => collecton.Any(c => type.Name.Contains(c)))

            IQueryable<TissueSample> query = Enumerable.Empty<TissueSample>().AsQueryable();

            var tissueSamples = query.Where(condition).ToList();
        }

        private static MethodInfo GetContainsMethod(Expression left)
        {
            const string methodName = "Contains";
            var containsMethod = left.Type.GetMethod(methodName, new[] { typeof(string) });

            if (containsMethod == null)
            {
                throw new ArgumentException(methodName, left.Type.Name);
            }

            return containsMethod;
        }
    }
}
