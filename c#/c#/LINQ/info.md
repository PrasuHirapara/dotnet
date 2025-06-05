### 1. Introduction to LINQ

#### 1.1 What is LINQ?

Language Integrated Query (LINQ) is a powerful feature introduced in .NET 3.5 that brings query capabilities into the .NET programming languages such as C# and VB.NET. LINQ allows developers to write structured, type-safe queries over collections of objects, databases, XML documents, and more. It bridges the gap between programming languages and data, eliminating the need for separate query languages like SQL for databases or XPath for XML. LINQ queries can be written using two main syntaxes: Query Syntax and Method Syntax, both of which are translated into the same intermediate language by the compiler.

LINQ introduces a declarative approach to querying, which results in more readable and maintainable code. It integrates closely with lambda expressions, extension methods, and anonymous types to provide a consistent model for working with data. LINQ supports various data sources through specialized providers such as LINQ to Objects, LINQ to SQL, LINQ to XML, and LINQ to Entities.

#### 1.2 Benefits of LINQ

LINQ offers several key benefits that enhance developer productivity and code quality:

* **Unified Querying:** A consistent syntax for querying different data sources like arrays, collections, databases, and XML.
* **Compile-Time Checking:** Strong typing ensures errors are caught at compile time.
* **IntelliSense Support:** Enhanced developer experience in IDEs like Visual Studio through auto-completion and documentation.
* **Improved Readability:** Declarative queries closely resemble SQL, making them easier to understand and maintain.
* **Less Code:** Many operations that require loops and temporary lists can be replaced with simple LINQ queries.
* **Integration with Language Features:** Seamless integration with other .NET features such as anonymous types, lambda expressions, and generics.

Example demonstrating LINQ's ability to simplify querying:

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

// Output: 2, 4, 6
```

#### 1.3 LINQ Providers (LINQ to Objects, LINQ to SQL, LINQ to XML, LINQ to Entities)

LINQ supports multiple data sources through various providers:

* **LINQ to Objects:** Used for querying in-memory collections such as arrays, lists, dictionaries, etc.
* **LINQ to SQL:** Allows querying Microsoft SQL Server databases. It converts LINQ queries into SQL commands.
* **LINQ to XML:** Designed for querying and modifying XML documents using the `System.Xml.Linq` namespace.
* **LINQ to Entities:** Integrates with Entity Framework to query relational databases using LINQ.

Each provider handles query translation and execution appropriate to the underlying data source. For instance, LINQ to SQL translates LINQ expressions to T-SQL, while LINQ to XML queries are executed in-memory.

Example - LINQ to XML:

```csharp
XElement booksXml = new XElement("Books",
    new XElement("Book", new XAttribute("Title", "C# Basics")),
    new XElement("Book", new XAttribute("Title", "LINQ Deep Dive"))
);

var titles = from book in booksXml.Elements("Book")
             select book.Attribute("Title").Value;

// Output: "C# Basics", "LINQ Deep Dive"
```

#### 1.4 LINQ Query Syntax vs Method Syntax

LINQ provides two primary syntaxes for writing queries:

* **Query Syntax:** Resembles SQL and is more readable for those familiar with database queries.
* **Method Syntax:** Utilizes extension methods and lambda expressions; often preferred for chaining operations.

Both syntaxes are interchangeable and can often be mixed in the same query.

Query Syntax Example:

```csharp
List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
var result = from name in names
             where name.StartsWith("C")
             select name;

// Output: "Charlie"
```

Method Syntax Example:

```csharp
List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
var result = names.Where(name => name.StartsWith("C"));

// Output: "Charlie"
```

---
### 2. LINQ Basics

#### 2.1 LINQ Query Syntax

LINQ Query Syntax offers a SQL-like way to write queries in C# or VB.NET. This style is more declarative and is preferred when readability is a priority. Common keywords include `from`, `where`, `select`, `orderby`, `group`, and `join`. The syntax compiles into method calls on IEnumerable or IQueryable objects.

**Example using `from`, `where`, `select`:**

```csharp
List<int> numbers = new List<int> { 10, 15, 20, 25, 30 };
var query = from num in numbers
            where num > 20
            select num;

// Output: 25, 30
```

**Example using `orderby`:**

```csharp
List<string> fruits = new List<string> { "Banana", "Apple", "Mango" };
var query = from fruit in fruits
            orderby fruit
            select fruit;

// Output: Apple, Banana, Mango
```

**Example using `group by`:**

```csharp
List<string> words = new List<string> { "ant", "bat", "apple", "banana" };
var grouped = from word in words
              group word by word[0];

/* Output:
 a -> ant, apple
 b -> bat, banana
*/
```

**Example using `join`:**

```csharp
List<int> ids = new List<int> { 1, 2, 3 };
List<string> names = new List<string> { "One", "Two", "Three" };
var query = from id in ids
            join name in names on id equals names.IndexOf(name) + 1
            select new { id, name };

/* Output:
 { id = 1, name = "One" }
 { id = 2, name = "Two" }
 { id = 3, name = "Three" }
*/
```

#### 2.2 LINQ Method Syntax (Extension Methods)

Method syntax uses lambda expressions and extension methods to construct queries. This style is concise and enables chaining multiple operations.

**Example using `Where()`:**

```csharp
List<int> scores = new List<int> { 70, 80, 90, 60 };
var passingScores = scores.Where(s => s >= 70);

// Output: 70, 80, 90
```

**Example using `Select()`:**

```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
var squares = numbers.Select(n => n * n);

// Output: 1, 4, 9
```

**Example using `OrderBy()`:**

```csharp
List<string> colors = new List<string> { "Blue", "Red", "Green" };
var sorted = colors.OrderBy(c => c);

// Output: Blue, Green, Red
```

**Example using `GroupBy()`:**

```csharp
List<string> names = new List<string> { "Anna", "Andy", "Brian", "Bella" };
var grouped = names.GroupBy(n => n[0]);

/* Output:
 A -> Anna, Andy
 B -> Brian, Bella
*/
```

**Example using `Join()`:**

```csharp
var students = new List<int> { 101, 102, 103 };
var studentNames = new List<(int id, string name)> {
    (101, "Alice"), (102, "Bob"), (103, "Charlie")
};

var joinResult = students.Join(
    studentNames,
    id => id,
    student => student.id,
    (id, student) => student.name
);

// Output: Alice, Bob, Charlie
```

#### 2.3 Deferred Execution vs Immediate Execution

In LINQ, **deferred execution** means that a query is not executed when it is defined but rather when it is iterated over. This allows for query composition and efficiency. **Immediate execution** occurs when the query result is forced into a collection using methods like `ToList()`, `ToArray()`, `Count()`, etc.

**Deferred Execution Example:**

```csharp
List<int> values = new List<int> { 1, 2, 3 };
var query = values.Where(v => v > 1);
values.Add(4);

foreach (var val in query)
{
    Console.WriteLine(val);
}

// Output: 2, 3, 4 (includes added value)
```

**Immediate Execution Example:**

```csharp
List<int> values = new List<int> { 1, 2, 3 };
var result = values.Where(v => v > 1).ToList();
values.Add(4);

foreach (var val in result)
{
    Console.WriteLine(val);
}

// Output: 2, 3 (query executed before adding 4)
```

#### 2.4 Anonymous Types in LINQ

Anonymous types are types created using the `new` keyword without defining a class. They are useful for returning multiple values in a LINQ query.

**Example:**

```csharp
var students = new[] { new { Name = "Tom", Age = 20 }, new { Name = "Jerry", Age = 22 } };
var result = students.Select(s => new { s.Name, YearOfBirth = 2025 - s.Age });

/* Output:
 { Name = "Tom", YearOfBirth = 2005 }
 { Name = "Jerry", YearOfBirth = 2003 }
*/
```

#### 2.5 var Keyword and Type Inference

The `var` keyword allows the compiler to infer the type of a variable from the expression on the right-hand side. In LINQ, this is especially helpful when dealing with anonymous types or complex queries.

**Example:**

```csharp
var fruits = new List<string> { "Apple", "Banana" };
var upperFruits = fruits.Select(f => f.ToUpper());

foreach (var fruit in upperFruits)
{
    Console.WriteLine(fruit);
}

// Output: APPLE, BANANA
```

---
### 3. Standard Query Operators

Standard query operators in LINQ are a set of extension methods that provide query capabilities directly over collections. These operators allow filtering, projection, sorting, grouping, joining, aggregating, and more.

---

#### 3.1 Filtering

Filtering operators are used to retrieve elements from a sequence based on specific criteria.

**Where()**: Filters elements based on a predicate (Boolean condition).

```csharp
List<int> nums = new List<int> { 5, 10, 15, 20 };
var filtered = nums.Where(n => n > 10);
// Output: 15, 20
```

**OfType<T>()**: Filters elements based on a specified type.

```csharp
ArrayList items = new ArrayList { 1, "Hello", 2, 3.5, 4 };
var integers = items.OfType<int>();
// Output: 1, 2, 4
```

---

#### 3.2 Projection

Projection transforms each element of a sequence into a new form.

**Select()**: Projects each element into a new form.

```csharp
List<string> names = new List<string> { "Tom", "Jerry" };
var lengths = names.Select(name => name.Length);
// Output: 3, 5
```

**SelectMany()**: Projects each element to an IEnumerable and flattens the resulting sequences.

```csharp
List<string[]> wordGroups = new List<string[]> {
    new string[] { "a", "b" },
    new string[] { "c", "d" }
};
var allWords = wordGroups.SelectMany(group => group);
// Output: a, b, c, d
```

---

#### 3.3 Sorting

Sorting operators arrange elements in ascending or descending order.

**OrderBy()**: Sorts elements in ascending order.

```csharp
List<int> values = new List<int> { 4, 2, 5, 1 };
var sorted = values.OrderBy(v => v);
// Output: 1, 2, 4, 5
```

**OrderByDescending()**: Sorts elements in descending order.

```csharp
var sorted = values.OrderByDescending(v => v);
// Output: 5, 4, 2, 1
```

**ThenBy()**: Performs a secondary ascending sort.

```csharp
var people = new List<(string name, int age)> {
    ("Alice", 30), ("Bob", 25), ("Alice", 25)
};
var ordered = people.OrderBy(p => p.name).ThenBy(p => p.age);
/* Output:
 ("Alice", 25)
 ("Alice", 30)
 ("Bob", 25)
*/
```

**ThenByDescending()**: Performs a secondary descending sort.

```csharp
var ordered = people.OrderBy(p => p.name).ThenByDescending(p => p.age);
/* Output:
 ("Alice", 30)
 ("Alice", 25)
 ("Bob", 25)
*/
```

**Reverse()**: Reverses the order of elements in a sequence.

```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
var reversed = numbers.AsEnumerable().Reverse();
// Output: 3, 2, 1
```

---

#### 3.4 Grouping

Grouping operators group elements based on a specified key.

**GroupBy()**: Groups elements that share a common key.

```csharp
var animals = new List<string> { "cat", "cow", "camel", "dog" };
var grouped = animals.GroupBy(a => a[0]);
/* Output:
 c -> cat, cow, camel
 d -> dog
*/
```

**ToLookup()**: Similar to GroupBy, but returns a Lookup, which is like a dictionary.

```csharp
var cities = new List<string> { "Rome", "Rio", "Riyadh", "Paris" };
var lookup = cities.ToLookup(c => c[0]);
/* Output:
 R -> Rome, Rio, Riyadh
 P -> Paris
*/
```

---

#### 3.5 Joining

Joining operators combine elements from two sequences based on a key.

**Join()**: Performs an inner join between two sequences.

```csharp
var ids = new List<int> { 1, 2, 3 };
var data = new List<(int id, string name)> {
    (1, "Alpha"), (2, "Beta"), (3, "Gamma")
};
var result = ids.Join(
    data,
    id => id,
    d => d.id,
    (id, d) => d.name
);
// Output: Alpha, Beta, Gamma
```

**GroupJoin()**: Performs a grouped join producing results with collections.

```csharp
var categories = new List<string> { "A", "B" };
var items = new List<(string cat, string item)> {
    ("A", "apple"), ("B", "banana"), ("A", "apricot")
};
var grouped = categories.GroupJoin(
    items,
    c => c,
    i => i.cat,
    (c, grp) => new { Category = c, Items = grp.Select(x => x.item) }
);
/* Output:
 A -> apple, apricot
 B -> banana
*/
```

---

#### 3.6 Aggregation

Aggregation operators compute a single value from a sequence.

**Count()**: Returns the number of elements.

```csharp
List<string> fruits = new List<string> { "apple", "banana", "cherry" };
var count = fruits.Count();
// Output: 3
```

**Sum()**: Computes the sum of numeric values.

```csharp
List<int> nums = new List<int> { 1, 2, 3 };
var total = nums.Sum();
// Output: 6
```

**Min() / Max()**: Finds the minimum or maximum value.

```csharp
var min = nums.Min(); // Output: 1
var max = nums.Max(); // Output: 3
```

**Average()**: Computes the average.

```csharp
var avg = nums.Average();
// Output: 2
```

**Aggregate()**: Applies an accumulator function over a sequence.

```csharp
var sentence = new List<string> { "Learning", "LINQ", "is", "fun" };
var combined = sentence.Aggregate((a, b) => a + " " + b);
// Output: "Learning LINQ is fun"
```

---

#### 3.7 Quantifiers

Quantifiers return Boolean values based on a condition.

**Any()**: Checks if any element satisfies a condition.

```csharp
List<int> nums = new List<int> { 1, 2, 3 };
bool hasEven = nums.Any(n => n % 2 == 0);
// Output: true
```

**All()**: Checks if all elements satisfy a condition.

```csharp
bool allPositive = nums.All(n => n > 0);
// Output: true
```

**Contains()**: Checks if the sequence contains a specific element.

```csharp
bool hasTwo = nums.Contains(2);
// Output: true
```

---

#### 3.8 Partitioning

Partitioning divides a sequence into parts.

**Skip() / SkipWhile()**: Skips a specified number or condition-based elements.

```csharp
var skipped = nums.Skip(1);
// Output: 2, 3

var skipWhile = nums.SkipWhile(n => n < 3);
// Output: 3
```

**Take() / TakeWhile()**: Takes a specified number or condition-based elements.

```csharp
var taken = nums.Take(2);
// Output: 1, 2

var takeWhile = nums.TakeWhile(n => n < 3);
// Output: 1, 2
```

---

#### 3.9 Set Operations

Set operators perform mathematical set operations.

**Distinct()**: Removes duplicates.

```csharp
List<int> data = new List<int> { 1, 2, 2, 3 };
var distinct = data.Distinct();
// Output: 1, 2, 3
```

**Union()**: Returns unique elements from both sequences.

```csharp
var union = new List<int> { 1, 2 }.Union(new List<int> { 2, 3 });
// Output: 1, 2, 3
```

**Intersect()**: Returns elements present in both sequences.

```csharp
var intersect = new List<int> { 1, 2, 3 }.Intersect(new List<int> { 2, 3, 4 });
// Output: 2, 3
```

**Except()**: Returns elements in the first sequence not present in the second.

```csharp
var except = new List<int> { 1, 2, 3 }.Except(new List<int> { 2 });
// Output: 1, 3
```

---

#### 3.10 Element Operations

Element operators return single elements from a sequence.

**First() / FirstOrDefault()**: Returns the first element (or default if empty).

```csharp
List<int> numbers = new List<int> { 10, 20 };
var first = numbers.First(); // Output: 10
var firstOrDefault = new List<int>().FirstOrDefault(); // Output: 0
```

**Last() / LastOrDefault()**: Returns the last element (or default if empty).

```csharp
var last = numbers.Last(); // Output: 20
```

**Single() / SingleOrDefault()**: Returns the only element (throws if not exactly one).

```csharp
var single = new List<int> { 42 }.Single(); // Output: 42
```

**ElementAt() / ElementAtOrDefault()**: Returns the element at a specific index.

```csharp
var element = numbers.ElementAt(1); // Output: 20
```

---

#### 3.11 Conversion

Conversion operators convert sequences to collections or types.

**ToList(), ToArray()**: Converts to a List or Array.

```csharp
var array = numbers.ToArray();
var list = numbers.ToList();
```

**ToDictionary()**: Converts to a Dictionary.

```csharp
var dict = new[] { "a", "bb" }.ToDictionary(s => s, s => s.Length);
// Output: {"a":1, "bb":2}
```

**Cast<T>()**: Casts elements to a specific type.

```csharp
IEnumerable<object> objList = new object[] { 1, 2, 3 };
var ints = objList.Cast<int>();
```

**AsEnumerable(), AsQueryable()**: Changes the static type of a sequence.

```csharp
var enumerable = numbers.AsEnumerable();
```

---

### 4. Advanced LINQ Concepts

#### 4.1 Deferred Execution & Lazy Evaluation

Deferred execution means the query is not executed when defined, but only when it is enumerated (e.g., using `foreach`, `.ToList()`, etc.). This behavior allows real-time data evaluation and efficient memory usage.

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
var query = numbers.Where(n => n > 2); // Query defined, not executed yet

numbers.Add(6); // Modify the source before execution

foreach (var n in query)
{
    Console.WriteLine(n);
}
// Output: 3, 4, 5, 6
```

**Complex Example:**

```csharp
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
var query = fruits.Where(f => f.Contains("a"));

fruits.Add("Mango");

Console.WriteLine(string.Join(", ", query));
// Output: Banana, Mango
```

#### 4.2 Expression Trees in LINQ

Expression trees allow LINQ to represent code as data, particularly useful in LINQ to SQL or dynamic LINQ providers. They allow the structure of a query to be inspected or translated.

```csharp
Expression<Func<int, bool>> expr = x => x > 5;
Console.WriteLine(expr.Body);  // Output: (x > 5)
```

**Complex Example:**

```csharp
ParameterExpression pe = Expression.Parameter(typeof(int), "n");
Expression body = Expression.GreaterThan(pe, Expression.Constant(10));
var expr = Expression.Lambda<Func<int, bool>>(body, pe);

var compiled = expr.Compile();
Console.WriteLine(compiled(15)); // True
Console.WriteLine(compiled(5));  // False
```

#### 4.3 IQueryable<T> vs IEnumerable<T>

`IEnumerable<T>` is used for in-memory collections and executes queries immediately. `IQueryable<T>` is used with remote sources (like databases) and supports deferred execution by translating LINQ to a provider-specific query language (e.g., SQL).

```csharp
List<int> localData = new List<int> { 1, 2, 3, 4 };
IEnumerable<int> enumQuery = localData.Where(x => x > 2); // In-memory filtering

IQueryable<int> queryableData = localData.AsQueryable();
var remoteQuery = queryableData.Where(x => x > 2); // Pretend this is EF or remote source
```

**Complex Example:**

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Pen", Price = 10 },
    new Product { Id = 2, Name = "Book", Price = 100 }
};

IQueryable<Product> qProducts = products.AsQueryable();
var expensive = qProducts.Where(p => p.Price > 50);

foreach (var p in expensive)
    Console.WriteLine(p.Name);  // Output: Book
```

#### 4.4 Dynamic LINQ Queries

Dynamic LINQ allows constructing queries using strings, which is useful for building filters or sort orders at runtime (e.g., user-driven interfaces).

```csharp
using System.Linq.Dynamic.Core;

List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
var result = names.AsQueryable().Where("it.StartsWith(@0)", "C");

foreach (var name in result)
    Console.WriteLine(name); // Output: Charlie
```

**Complex Example:**

```csharp
List<Product> items = new List<Product>
{
    new Product { Id = 1, Name = "Mouse", Price = 25 },
    new Product { Id = 2, Name = "Keyboard", Price = 75 }
};

var expensive = items.AsQueryable().Where("Price > @0", 50);
foreach (var item in expensive)
    Console.WriteLine(item.Name); // Output: Keyboard
```

#### 4.5 PLINQ (Parallel LINQ)

PLINQ enables data parallelism by distributing LINQ query execution across multiple processors or cores. Ideal for CPU-bound operations.

```csharp
List<int> numbers = Enumerable.Range(1, 10).ToList();
var squares = numbers.AsParallel().Select(n => n * n);

foreach (var sq in squares)
    Console.WriteLine(sq);
```

**Complex Example:**

```csharp
List<string> data = Enumerable.Range(1, 1000).Select(i => $"Item{i}").ToList();
var upper = data.AsParallel()
                .WithDegreeOfParallelism(4)
                .Select(s => s.ToUpper())
                .ToList();

Console.WriteLine(upper.Take(5).First()); // Output: ITEM1
```

#### 4.6 Custom LINQ Providers

A custom LINQ provider allows querying over non-standard data sources by implementing `IQueryable` and `IQueryProvider`. This enables LINQ to operate on XML, JSON, REST APIs, etc.

Creating a custom provider is an advanced task, involving expression tree parsing and query translation.

**Complex Outline Example:**

```csharp
// Define classes that implement IQueryable and IQueryProvider
// Parse Expression trees
// Translate to custom logic (e.g., REST endpoint call)
```

This approach is used by ORMs and libraries like Entity Framework and RavenDB.

#### 4.7 LINQ Performance Considerations

Writing performant LINQ requires attention to how and when queries execute. Repeated enumeration or redundant filtering can degrade performance.

```csharp
List<int> numbers = Enumerable.Range(1, 100).ToList();

// Bad
bool exists = numbers.Count(n => n > 50) > 0;

// Better
bool existsOptimized = numbers.Any(n => n > 50);
```

**Complex Example:**

```csharp
List<Product> catalog = Enumerable.Range(1, 1000)
    .Select(i => new Product { Id = i, Name = $"P{i}", Price = i })
    .ToList();

// Inefficient: executes query multiple times
var expensiveItems = catalog.Where(p => p.Price > 900);
Console.WriteLine(expensiveItems.Count()); // First exec
Console.WriteLine(expensiveItems.First().Name); // Second exec

// Optimized
var cached = expensiveItems.ToList();
Console.WriteLine(cached.Count);  // One execution
Console.WriteLine(cached.First().Name);
```

#### 4.8 LINQ with async/await

In async environments (e.g., ASP.NET Core), LINQ supports async methods via EF Core with `.ToListAsync()`, `.FirstOrDefaultAsync()`, etc., for non-blocking queries.

```csharp
using Microsoft.EntityFrameworkCore;

var users = await dbContext.Users
                .Where(u => u.IsActive)
                .ToListAsync();
```

**Complex Example:**

```csharp
var activeAdmins = await dbContext.Users
    .Where(u => u.IsActive && u.Roles.Contains("Admin"))
    .OrderBy(u => u.LastLogin)
    .ToListAsync();

foreach (var admin in activeAdmins)
    Console.WriteLine($"{admin.Name}: {admin.LastLogin}");
```

---

### 5. LINQ with Different Data Sources

#### 5.1 LINQ to Objects (In-Memory Collections)

LINQ to Objects allows querying in-memory collections like arrays, lists, and other IEnumerable<T> collections. It uses standard LINQ syntax to filter, sort, and project data.

```csharp
List<string> cities = new List<string> { "Delhi", "Mumbai", "Chennai", "Kolkata", "Bangalore" };
var query = from city in cities
            where city.Contains("a")
            orderby city descending
            select city;

foreach (var c in query)
    Console.WriteLine(c);
// Output: Kolkata, Bangalore, Chennai, Mumbai
```

Complex Example:

```csharp
List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1, Name = "Alice", Department = "HR" },
    new Employee { Id = 2, Name = "Bob", Department = "IT" },
    new Employee { Id = 3, Name = "Carol", Department = "HR" },
    new Employee { Id = 4, Name = "Dave", Department = "Finance" }
};

var grouped = from emp in employees
              group emp by emp.Department into deptGroup
              select new
              {
                  Department = deptGroup.Key,
                  Members = deptGroup.ToList()
              };

foreach (var group in grouped)
{
    Console.WriteLine($"Department: {group.Department}");
    foreach (var member in group.Members)
        Console.WriteLine(" - " + member.Name);
}
```

#### 5.2 LINQ to SQL (Legacy)

LINQ to SQL allows querying SQL Server databases using strongly-typed C# classes that represent database tables. Though legacy, it paved the way for Entity Framework.

```csharp
DataContext db = new DataContext("connectionString");
Table<Customer> customers = db.GetTable<Customer>();

var result = from c in customers
             where c.City == "London"
             select c;

foreach (var c in result)
    Console.WriteLine(c.Name);
```

Complex Example:

```csharp
var ordersByCustomer = from c in db.GetTable<Customer>()
                       join o in db.GetTable<Order>() on c.CustomerID equals o.CustomerID
                       where o.OrderDate >= new DateTime(2020, 1, 1)
                       group o by c.CompanyName into customerGroup
                       select new
                       {
                           Company = customerGroup.Key,
                           Orders = customerGroup.Count()
                       };
```

#### 5.3 LINQ to Entities (Entity Framework Core)

LINQ to Entities allows querying a database using Entity Framework. It supports rich mapping, navigation properties, lazy/eager loading, and async LINQ queries.

```csharp
var users = context.Users
                   .Where(u => u.IsActive)
                   .OrderBy(u => u.LastName)
                   .Select(u => new { u.FirstName, u.Email })
                   .ToList();
```

Complex Example:

```csharp
var userStats = context.Users
                       .Where(u => u.IsActive)
                       .GroupBy(u => u.Role)
                       .Select(g => new
                       {
                           Role = g.Key,
                           Count = g.Count(),
                           Latest = g.Max(u => u.LastLogin)
                       })
                       .ToList();
```

#### 5.4 LINQ to XML

LINQ to XML provides an elegant way to query and transform XML documents using XDocument and XElement classes.

```csharp
XDocument doc = XDocument.Load("books.xml");
var titles = from b in doc.Descendants("book")
             where (int)b.Element("price") > 30
             select b.Element("title").Value;

foreach (var t in titles)
    Console.WriteLine(t);
```

Complex Example:

```csharp
var groupedBooks = from book in doc.Descendants("book")
                   group book by (string)book.Element("genre") into genreGroup
                   select new
                   {
                       Genre = genreGroup.Key,
                       Titles = genreGroup.Select(x => x.Element("title").Value).ToList()
                   };

foreach (var g in groupedBooks)
{
    Console.WriteLine("Genre: " + g.Genre);
    foreach (var title in g.Titles)
        Console.WriteLine(" - " + title);
}
```

#### 5.5 LINQ to JSON (using System.Text.Json or Newtonsoft.Json)

LINQ to JSON (via Newtonsoft.Json) allows querying JSON structures as if they were XML or objects using JToken, JObject, and JArray.

```csharp
string json = File.ReadAllText("data.json");
JObject obj = JObject.Parse(json);

var names = obj["employees"]
    .Where(e => (int)e["age"] > 30)
    .Select(e => (string)e["name"]);

foreach (var name in names)
    Console.WriteLine(name);
```

Complex Example:

```csharp
var grouped = obj["employees"]
    .GroupBy(e => (string)e["department"])
    .Select(g => new
    {
        Department = g.Key,
        Count = g.Count(),
        Names = g.Select(e => (string)e["name"])
    });

foreach (var group in grouped)
{
    Console.WriteLine($"Department: {group.Department} ({group.Count})");
    foreach (var name in group.Names)
        Console.WriteLine(" - " + name);
}
```

---
### 6. Real-World LINQ Examples & Best Practices

#### 6.1 Complex Query Examples (Nested Queries, Multiple Joins)

LINQ supports complex operations similar to SQL, allowing nested queries and multiple joins across collections. This enables readable and maintainable code for non-trivial data operations.

**Multiple Joins Example:**

```csharp
var departments = new[]
{
    new { Id = 1, Name = "HR" },
    new { Id = 2, Name = "IT" }
};

var employees = new[]
{
    new { Id = 1, Name = "Alice", DepartmentId = 2 },
    new { Id = 2, Name = "Bob", DepartmentId = 1 },
    new { Id = 3, Name = "Charlie", DepartmentId = 2 }
};

var query = from emp in employees
            join dept in departments on emp.DepartmentId equals dept.Id
            select new { emp.Name, Department = dept.Name };

foreach (var item in query)
    Console.WriteLine($"{item.Name} - {item.Department}");

// Output:
// Alice - IT
// Bob - HR
// Charlie - IT
```

**Nested Query Example:**

```csharp
var highPaidEmployees = new[]
{
    new { Name = "John", Salary = 1000 },
    new { Name = "Sara", Salary = 3000 },
    new { Name = "Mike", Salary = 2000 }
};

var maxSalary = highPaidEmployees.Max(e => e.Salary);
var richest = highPaidEmployees.Where(e => e.Salary == maxSalary);

foreach (var emp in richest)
    Console.WriteLine(emp.Name);

// Output:
// Sara
```

#### 6.2 Using LINQ for Data Transformation

LINQ's projection capabilities allow you to reshape data for different purposes such as UI models, API contracts, or intermediate DTOs.

```csharp
var users = new[]
{
    new { Id = 1, FirstName = "Tom", LastName = "Hanks" },
    new { Id = 2, FirstName = "Emma", LastName = "Stone" }
};

var displayUsers = users.Select(u => new
{
    u.Id,
    FullName = $"{u.FirstName} {u.LastName}"
});

foreach (var user in displayUsers)
    Console.WriteLine($"{user.Id}: {user.FullName}");

// Output:
// 1: Tom Hanks
// 2: Emma Stone
```

#### 6.3 LINQ in Web APIs & Database Operations

In ASP.NET Core applications using Entity Framework, LINQ is commonly used to perform filtering, projection, and pagination within Web API controllers:

```csharp
[HttpGet("active-users")]
public async Task<IActionResult> GetActiveUsers()
{
    var result = await _context.Users
        .Where(u => u.IsActive)
        .Select(u => new { u.Id, u.Name })
        .ToListAsync();

    return Ok(result);
}
```

This allows efficient server-side querying while minimizing data sent to the client.

#### 6.4 When to Use LINQ vs Raw SQL

| Scenario                    | Use LINQ   | Use Raw SQL |
| --------------------------- | ---------- | ----------- |
| Simple filtering/projection | Yes        |             |
| Complex joins/subqueries    | Cautiously | Yes         |
| Performance-critical code   |            | Yes         |
| DB-specific features        |            | Yes         |

**LINQ is preferred** when readability and maintainability are important. **Raw SQL** is better suited when you need optimized performance, special database features, or operations unsupported by LINQ.

#### 6.5 Debugging LINQ Queries (Using Debugger Visualizers)

Effective debugging of LINQ queries is essential for correctness and performance. Visual Studio offers several ways to examine queries:

* Use `.ToList()` temporarily to force query execution and inspect results.
* Use breakpoints to inspect collections.
* Leverage tools like LINQPad for isolated query testing.

```csharp
var data = Enumerable.Range(1, 10).Where(x => x % 2 == 0);
var list = data.ToList();  // Use a breakpoint here to examine 'list'

foreach (var num in list)
    Console.WriteLine(num);

// Output:
// 2
// 4
// 6
// 8
// 10
```

---

