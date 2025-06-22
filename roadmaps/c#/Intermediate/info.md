Abstract Classes Implementation
-------------------------------

Abstract classes serve as blueprints for other classes. They cannot be instantiated directly and may contain abstract members (methods and properties) that must be implemented by derived classes.

*   **Defining Abstract Classes:** Use the `abstract` keyword.
*   **Abstract Members:** Declared with the `abstract` keyword. They have no implementation in the abstract class.
*   **Concrete Members:** Abstract classes can also contain concrete (implemented) members.

    public abstract class Shape
    {
        public abstract double Area(); // Abstract method
    
        public virtual string Description() // Virtual method
        {
            return "A shape.";
        }
    
        public void Display() // Concrete method
        {
            Console.WriteLine("Displaying shape.");
        }
    }
    
    public class Circle : Shape
    {
        public double Radius { get; set; }
    
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    
        public override string Description()
        {
            return "A circle with radius " + Radius;
        }
    }
    

Interfaces Multiple Inheritance
-------------------------------

C# does not support multiple inheritance of classes, but a class can implement multiple interfaces. This allows a class to adhere to multiple contracts.

*   **Defining Interfaces:** Use the `interface` keyword.
*   **Interface Members:** Contain only signatures (no implementation).
*   **Multiple Inheritance:** A class can implement multiple interfaces, separating concerns and promoting code reusability.

    public interface IPrintable
    {
        void Print();
    }
    
    public interface ISaveable
    {
        void Save();
    }
    
    public class Document : IPrintable, ISaveable
    {
        public void Print()
        {
            Console.WriteLine("Printing document.");
        }
    
        public void Save()
        {
            Console.WriteLine("Saving document.");
        }
    }
    

Polymorphism Virtual Methods
----------------------------

Polymorphism allows objects of different classes to be treated as objects of a common type. Virtual methods enable derived classes to override the behavior of base class methods.

*   **Virtual Methods:** Declared with the `virtual` keyword in the base class.
*   **Override Methods:** Declared with the `override` keyword in the derived class.
*   **Runtime Polymorphism:** The actual method called is determined at runtime based on the object's type.

    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Generic animal sound.");
        }
    }
    
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
    
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
    
    // Usage
    Animal animal1 = new Animal();
    Animal animal2 = new Dog();
    Animal animal3 = new Cat();
    
    animal1.MakeSound(); // Output: Generic animal sound.
    animal2.MakeSound(); // Output: Woof!
    animal3.MakeSound(); // Output: Meow!
    

OOP Deep Dive
-------------

Object-Oriented Programming (OOP) is a programming paradigm based on the concept of "objects," which contain data and code to manipulate that data. Key principles include:

*   **Encapsulation:** Bundling data and methods that operate on that data within a class. This protects the data from outside access and misuse. Access modifiers like `private`, `protected`, and `public` control visibility.
*   **Abstraction:** Hiding complex implementation details and exposing only essential information. Abstract classes and interfaces are key tools for abstraction.
*   **Inheritance:** Creating new classes (derived classes) from existing classes (base classes). This promotes code reuse and establishes an "is-a" relationship.
*   **Polymorphism:** The ability of objects of different classes to respond to the same method call in their own way. This is achieved through virtual methods and interfaces.

Design Pattern Strategy
-----------------------

The Strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. It lets the algorithm vary independently from clients that use it.

*   **Context:** Contains a reference to a strategy object.
*   **Strategy Interface:** Defines the interface for all supported algorithms.
*   **Concrete Strategies:** Implement the strategy interface.

    // Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
    
    // Concrete Strategies
    public class CreditCardPayment : IPaymentStrategy
    {
        private string cardNumber;
        private string expiryDate;
        private string cvv;
    
        public CreditCardPayment(string cardNumber, string expiryDate, string cvv)
        {
            this.cardNumber = cardNumber;
            this.expiryDate = expiryDate;
            this.cvv = cvv;
        }
    
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card: {cardNumber}");
        }
    }
    
    public class PayPalPayment : IPaymentStrategy
    {
        private string email;
    
        public PayPalPayment(string email)
        {
            this.email = email;
        }
    
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using PayPal: {email}");
        }
    }
    
    // Context
    public class ShoppingCart
    {
        private IPaymentStrategy paymentStrategy;
    
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }
    
        public void Checkout(decimal amount)
        {
            paymentStrategy.Pay(amount);
        }
    }
    
    // Usage
    ShoppingCart cart = new ShoppingCart();
    cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456", "12/24", "123"));
    cart.Checkout(100.00m); // Output: Paid 100 using Credit Card: 1234-5678-9012-3456
    
    cart.SetPaymentStrategy(new PayPalPayment("user@example.com"));
    cart.Checkout(50.00m); // Output: Paid 50 using PayPal: user@example.com
    

Design Pattern Observer
-----------------------

The Observer pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

*   **Subject:** Maintains a list of observers and notifies them of state changes.
*   **Observer Interface:** Defines the interface for objects that want to be notified of changes in the subject.
*   **Concrete Observers:** Implement the observer interface and react to notifications from the subject.

    // Observer Interface
    public interface IObserver
    {
        void Update(string message);
    }
    
    // Concrete Observers
    public class EmailNotification : IObserver
    {
        private string email;
    
        public EmailNotification(string email)
        {
            this.email = email;
        }
    
        public void Update(string message)
        {
            Console.WriteLine($"Email sent to {email}: {message}");
        }
    }
    
    public class SMSNotification : IObserver
    {
        private string phoneNumber;
    
        public SMSNotification(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
    
        public void Update(string message)
        {
            Console.WriteLine($"SMS sent to {phoneNumber}: {message}");
        }
    }
    
    // Subject
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }
    
    public class NewsPublisher : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
    
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }
    
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }
    
        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    
        public void PublishNews(string news)
        {
            Console.WriteLine($"News published: {news}");
            Notify(news);
        }
    }
    
    // Usage
    NewsPublisher publisher = new NewsPublisher();
    EmailNotification emailObserver = new EmailNotification("user@example.com");
    SMSNotification smsObserver = new SMSNotification("123-456-7890");
    
    publisher.Attach(emailObserver);
    publisher.Attach(smsObserver);
    
    publisher.PublishNews("Breaking News: New product launched!");
    // Output:
    // News published: Breaking News: New product launched!
    // Email sent to user@example.com: Breaking News: New product launched!
    // SMS sent to 123-456-7890: Breaking News: New product launched!
    
    publisher.Detach(smsObserver);
    publisher.PublishNews("Another news update.");
    // Output:
    // News published: Another news update.
    // Email sent to user@example.com: Another news update.
    

Plugin System Exercise
----------------------

A plugin system allows you to extend the functionality of an application without modifying its core code.

1.  **Define a Plugin Interface:** This interface specifies the methods that all plugins must implement.
    
        public interface IPlugin
        {
            string Name { get; }
            string Description { get; }
            void Execute();
        }
        
    
2.  **Create a Plugin Loader:** This class is responsible for discovering and loading plugins from a specified directory. It uses reflection to find classes that implement the `IPlugin` interface.
    
        public class PluginLoader
        {
            public static List<IPlugin> LoadPlugins(string pluginDirectory)
            {
                List<IPlugin> plugins = new List<IPlugin>();
        
                if (!Directory.Exists(pluginDirectory))
                {
                    return plugins;
                }
        
                string[] pluginFiles = Directory.GetFiles(pluginDirectory, "*.dll");
        
                foreach (string pluginFile in pluginFiles)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(pluginFile);
        
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                            {
                                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                plugins.Add(plugin);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading plugin from {pluginFile}: {ex.Message}");
                    }
                }
        
                return plugins;
            }
        }
        
    
3.  **Implement Concrete Plugins:** Create classes that implement the `IPlugin` interface. These are your actual plugins.
    
        // Example Plugin
        public class MyPlugin : IPlugin
        {
            public string Name => "My Plugin";
            public string Description => "A simple example plugin.";
        
            public void Execute()
            {
                Console.WriteLine("My Plugin is executing!");
            }
        }
        
    
4.  **Application Core:** The main application uses the `PluginLoader` to load plugins and then executes them.
    
        // Main Application
        public class Program
        {
            public static void Main(string[] args)
            {
                string pluginDirectory = "Plugins"; // Create a "Plugins" folder in your project
        
                List<IPlugin> plugins = PluginLoader.LoadPlugins(pluginDirectory);
        
                if (plugins.Count == 0)
                {
                    Console.WriteLine("No plugins found.");
                    return;
                }
        
                foreach (IPlugin plugin in plugins)
                {
                    Console.WriteLine($"Plugin Name: {plugin.Name}");
                    Console.WriteLine($"Plugin Description: {plugin.Description}");
                    plugin.Execute();
                    Console.WriteLine();
                }
            }
        }
        
    
5.  **Build and Deploy:** Build your plugin projects and copy the resulting DLL files into the "Plugins" directory. When you run the main application, it will load and execute the plugins.
    

Advanced Collection Types
-------------------------

Beyond the basic `List<T>`, `Dictionary<TKey, TValue>`, and `HashSet<T>`, C# offers more specialized collection types:

*   **`Queue<T>`:** Represents a first-in, first-out (FIFO) collection. Useful for processing items in the order they were added.
*   **`Stack<T>`:** Represents a last-in, first-out (LIFO) collection. Useful for undo/redo functionality or parsing expressions.
*   **`LinkedList<T>`:** Represents a doubly linked list. Efficient for inserting and removing elements in the middle of the list.
*   **`SortedList<TKey, TValue>`:** Similar to `Dictionary<TKey, TValue>`, but the keys are automatically sorted.
*   **`SortedDictionary<TKey, TValue>`:** Similar to `SortedList<TKey, TValue>`, but implemented as a binary search tree, offering better performance for large collections.
*   **`BlockingCollection<T>`:** Provides blocking and bounding capabilities for thread-safe collection operations. Useful for producer/consumer scenarios.
*   **`ConcurrentBag<T>`:** An unordered collection of objects that is optimized for concurrent access.
*   **`ConcurrentQueue<T>`:** A thread-safe FIFO queue.
*   **`ConcurrentStack<T>`:** A thread-safe LIFO stack.
*   **`ImmutableList<T>`, `ImmutableDictionary<TKey, TValue>`, etc.:** Immutable collections that cannot be modified after creation. Useful for thread safety and data integrity.

Custom Collection Classes
-------------------------

You can create your own collection classes by implementing the `IEnumerable<T>`, `ICollection<T>`, and `IList<T>` interfaces.

*   **`IEnumerable<T>`:** Provides the basic functionality for iterating over a collection using `foreach`. You must implement the `GetEnumerator()` method.
*   **`ICollection<T>`:** Extends `IEnumerable<T>` and adds methods for adding, removing, and checking the size of the collection.
*   **`IList<T>`:** Extends `ICollection<T>` and adds methods for accessing elements by index.

    public class MyList<T> : IList<T>
    {
        private T[] items;
        private int size;
    
        public MyList()
        {
            items = new T[4]; // Initial capacity
            size = 0;
        }
    
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }
    
        public int Count => size;
    
        public bool IsReadOnly => false;
    
        public void Add(T item)
        {
            if (size == items.Length)
            {
                // Resize the array
                Array.Resize(ref items, items.Length * 2);
            }
            items[size] = item;
            size++;
        }
    
        public void Clear()
        {
            Array.Clear(items, 0, size);
            size = 0;
        }
    
        public bool Contains(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(items[i], item))
                {
                    return true;
                }
            }
            return false;
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, size);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return items[i];
            }
        }
    
        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }
    
        public void Insert(int index, T item)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }
    
            if (size == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
    
            Array.Copy(items, index, items, index + 1, size - index);
            items[index] = item;
            size++;
        }
    
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
    
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
    
            Array.Copy(items, index + 1, items, index, size - index - 1);
            size--;
            items[size] = default(T); // Help GC
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    

Generic Constraints Usage
-------------------------

Generic constraints restrict the types that can be used as type arguments for a generic type or method.

*   **`where T : class`:** `T` must be a reference type.
*   **`where T : struct`:** `T` must be a value type.
*   **`where T : new()`:** `T` must have a parameterless constructor.
*   **`where T : <base class name>`:** `T` must be or derive from the specified base class.
*   **`where T : <interface name>`:** `T` must implement the specified interface.
*   **`where T : U`:** `T` must be or derive from the type argument `U`.

    public class DataStore<T> where T : class, ICloneable, new()
    {
        private T data;
    
        public DataStore()
        {
            data = new T(); // Valid because of the new() constraint
        }
    
        public void SetData(T value)
        {
            if (value is ICloneable)
            {
                data = (T)((ICloneable)value).Clone();
            }
            else
            {
                data = value;
            }
        }
    
        public T GetData()
        {
            return data;
        }
    }
    

Collections and Generics
------------------------

Generics allow you to create type-safe collections that can work with any data type. The `System.Collections.Generic` namespace provides a wide range of generic collection classes.

*   **Type Safety:** Generics prevent you from accidentally adding the wrong type of object to a collection.
*   **Performance:** Generics avoid the need for boxing and unboxing value types, which can improve performance.
*   **Code Reusability:** You can write a single generic collection class that can be used with many different data types.

Generics Variance Handling
--------------------------

Variance allows you to use generic types with different type arguments in a more flexible way. C# supports covariance and contravariance.

*   **Covariance (`out`):** Allows you to use a more derived type than specified in the generic type parameter. For example, `IEnumerable<string>` can be treated as `IEnumerable<object>`. Covariance is only allowed for output parameters (return values).
*   **Contravariance (`in`):** Allows you to use a less derived type than specified in the generic type parameter. For example, `Action<object>` can be treated as `Action<string>`. Contravariance is only allowed for input parameters.
*   **Invariance:** The type parameter must match exactly. For example, `List<string>` is not compatible with `List<object>`.

    // Covariance
    interface ICovariant<out T> {
        T GetSomething();
    }
    
    class CovariantClass<T> : ICovariant<T> {
        public T GetSomething() { return default(T); }
    }
    
    // Contravariance
    interface IContravariant<in T> {
        void DoSomething(T arg);
    }
    
    class ContravariantClass<T> : IContravariant<T> {
        public void DoSomething(T arg) { }
    }
    
    // Usage
    ICovariant<string> stringCovariant = new CovariantClass<string>();
    ICovariant<object> objectCovariant = stringCovariant; // Covariance
    
    IContravariant<object> objectContravariant = new ContravariantClass<object>();
    IContravariant<string> stringContravariant = objectContravariant; // Contravariance
    

Generic Algorithms Implementation
---------------------------------

You can implement generic algorithms that work with any type that satisfies certain constraints.

    public static class Algorithm
    {
        public static T FindMax<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
    
            T max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
    
    // Usage
    List<int> numbers = new List<int> { 1, 5, 2, 8, 3 };
    int maxNumber = Algorithm.FindMax(numbers); // maxNumber = 8
    
    List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
    string maxName = Algorithm.FindMax(names); // maxName = "Charlie"
    

Generic Repository Exercise
---------------------------

A generic repository provides a common interface for accessing and managing data of different types.

1.  **Define an Entity Interface:** This interface represents the base entity for all your data models.
    
        public interface IEntity
        {
            int Id { get; set; }
        }
        
    
2.  **Define a Generic Repository Interface:** This interface specifies the common operations for accessing and managing entities.
    
        public interface IRepository<T> where T : class, IEntity
        {
            T GetById(int id);
            IEnumerable<T> GetAll();
            void Add(T entity);
            void Update(T entity);
            void Delete(int id);
        }
        
    
3.  **Implement a Concrete Repository:** This class implements the `IRepository<T>` interface and provides the actual data access logic. You can use Entity Framework or any other data access technology.
    
        public class GenericRepository<T> : IRepository<T> where T : class, IEntity
        {
            private readonly DbContext context;
            private readonly DbSet<T> dbSet;
        
            public GenericRepository(DbContext context)
            {
                this.context = context;
                this.dbSet = context.Set<T>();
            }
        
            public T GetById(int id)
            {
                return dbSet.Find(id);
            }
        
            public IEnumerable<T> GetAll()
            {
                return dbSet.ToList();
            }
        
            public void Add(T entity)
            {
                dbSet.Add(entity);
                context.SaveChanges();
            }
        
            public void Update(T entity)
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        
            public void Delete(int id)
            {
                T entity = dbSet.Find(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
        
    
4.  **Define your Entities:** Create classes that implement the `IEntity` interface.
    
        public class Product : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        
    
5.  **Usage:**
    
        // Assuming you have a DbContext instance
        using (var context = new MyDbContext())
        {
            IRepository<Product> productRepository = new GenericRepository<Product>(context);
        
            // Add a new product
            Product newProduct = new Product { Name = "New Product", Price = 19.99m };
            productRepository.Add(newProduct);
        
            // Get all products
            IEnumerable<Product> products = productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }
        }
        
    

Task Parallel Library
---------------------

The Task Parallel Library (TPL) simplifies parallel and concurrent programming in C#. It provides a higher-level abstraction over threads, making it easier to write efficient and scalable code.

*   **`Task`:** Represents an asynchronous operation. Tasks can be run in parallel or concurrently.
*   **`Task<T>`:** Represents an asynchronous operation that returns a value.
*   **`Parallel.For` and `Parallel.ForEach`:** Provide a simple way to parallelize loops.
*   **`async` and `await`:** Keywords that simplify asynchronous programming.

    using System.Threading.Tasks;
    
    public class Example
    {
        public static void ProcessData(List<int> data)
        {
            // Parallel.ForEach
            Parallel.ForEach(data, item =>
            {
                // Process each item in parallel
                Console.WriteLine($"Processing item: {item} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100); // Simulate some work
            });
    
            // Parallel.For
            Parallel.For(0, data.Count, i =>
            {
                // Process each item in parallel
                Console.WriteLine($"Processing item at index {i}: {data[i]} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100); // Simulate some work
            });
    
            // Task.Run
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine($"Task 1 running on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                Console.WriteLine("Task 1 completed.");
            });
    
            Task<int> task2 = Task.Run(() =>
            {
                Console.WriteLine($"Task 2 running on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine("Task 2 completed.");
                return 42;
            });
    
            // Wait for tasks to complete
            Task.WaitAll(task1, task2);
    
            Console.WriteLine($"Task 2 result: {task2.Result}");
        }
    }
    

Async Await Methods
-------------------

The `async` and `await` keywords provide a simple way to write asynchronous code that looks and behaves like synchronous code.

*   **`async`:** Indicates that a method is asynchronous and can contain `await` expressions. An `async` method must have a return type of `void`, `Task`, or `Task<T>`.
*   **`await`:** Suspends the execution of the `async` method until the awaited task completes. The `await` keyword can only be used inside an `async` method.

    public async Task<string> DownloadDataAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            // Await the completion of the GetStringAsync method
            string data = await client.GetStringAsync(url);
            return data;
        }
    }
    
    public async Task ProcessDataAsync()
    {
        Console.WriteLine("Starting data download...");
        string data = await DownloadDataAsync("https://www.example.com");
        Console.WriteLine("Data downloaded.");
        Console.WriteLine($"Data length: {data.Length}");
    }
    

Async Exceptions Handling
-------------------------

When working with `async` and `await`, exceptions are handled differently than in synchronous code.

*   **Exceptions in `async` methods:** Exceptions thrown in an `async` method are captured and propagated to the caller when the task is awaited.
*   **`AggregateException`:** If multiple exceptions occur in parallel tasks, they are wrapped in an `AggregateException`.
*   **`try-catch` blocks:** You can use `try-catch` blocks to handle exceptions in `async` methods, just like in synchronous code.

    public async Task DoSomethingAsync()
    {
        try
        {
            // Simulate an exception
            await Task.Delay(100);
            throw new Exception("Something went wrong!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
    
    public async Task ProcessTasksAsync()
    {
        Task task1 = DoSomethingAsync();
        Task task2 = Task.Run(() => { throw new InvalidOperationException("Task 2 failed."); });
    
        try
        {
            await Task.WhenAll(task1, task2);
        }
        catch (AggregateException ex)
        {
            foreach (var innerException in ex.InnerExceptions)
            {
                Console.WriteLine($"Inner Exception: {innerException.Message}");
            }
        }
    }
    

Async and Multithreading
------------------------

`async` and `await` are not the same as multithreading. `async` and `await` allow you to write non-blocking code that can improve the responsiveness of your application, but they don't necessarily create new threads.

*   **`async` and `await`:** Typically use the thread pool to execute tasks. They allow the current thread to be released while waiting for an asynchronous operation to complete.
*   **Multithreading:** Explicitly creates new threads to perform work in parallel. This can improve performance for CPU-bound tasks, but it also introduces complexity and overhead.

Threads Thread Pools
--------------------

*   **Threads:** Represent an independent execution path within a process. Creating and managing threads directly can be complex and resource-intensive.
*   **Thread Pools:** A collection of pre-created threads that are managed by the system. Using the thread pool is more efficient than creating new threads for each task. The `ThreadPool.QueueUserWorkItem` method allows you to queue work items to the thread pool.

    using System.Threading;
    
    public class Example
    {
        public static void UseThreadPool()
        {
            // Queue a work item to the thread pool
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), "Hello from the thread pool!");
    
            Console.WriteLine("Main thread continues to execute...");
            Thread.Sleep(1000); // Wait for the thread pool to complete
        }
    
        static void DoWork(object state)
        {
            Console.WriteLine($"Work item started on thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"State: {state}");
            Thread.Sleep(500);
            Console.WriteLine("Work item completed.");
        }
    
        public static void CreateAndManageThread()
        {
            Thread myThread = new Thread(new ThreadStart(DoWorkOnThread));
            myThread.Start();
    
            Console.WriteLine("Main thread continues...");
            myThread.Join(); // Wait for the thread to complete
            Console.WriteLine("Thread completed.");
        }
    
        static void DoWorkOnThread()
        {
            Console.WriteLine($"Work started on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
            Console.WriteLine("Work completed on thread.");
        }
    }
    

Synchronization Primitives Implementation
-----------------------------------------

Synchronization primitives are used to coordinate access to shared resources in multithreaded applications.

*   **`lock`:** Acquires an exclusive lock on an object, preventing other threads from accessing it.
*   **`Mutex`:** Similar to `lock`, but can be used across multiple processes.
*   **`Semaphore`:** Limits the number of threads that can access a resource concurrently.
*   **`Monitor`:** Provides more fine-grained control over locking and synchronization.
*   **`Interlocked`:** Provides atomic operations for incrementing, decrementing, and exchanging variables.
*   **`ReaderWriterLockSlim`:** Allows multiple readers to access a resource concurrently, but only one writer at a time.

    using System.Threading;
    
    public class Example
    {
        private static int counter = 0;
        private static object lockObject = new object();
        private static Mutex mutex = new Mutex();
        private static Semaphore semaphore = new Semaphore(3, 3); // Allow 3 concurrent threads
    
        public static void UseLock()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                {
                    lock (lockObject)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered lock.");
                        counter++;
                        Console.WriteLine($"Counter: {counter}");
                        Thread.Sleep(100);
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} exiting lock.");
                    }
                }).Start();
            }
        }
    
        public static void UseMutex()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                {
                    mutex.WaitOne(); // Acquire the mutex
                    try
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered mutex.");
                        counter++;
                        Console.WriteLine($"Counter: {counter}");
                        Thread.Sleep(100);
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} exiting mutex.");
                    }
                    finally
                    {
                        mutex.ReleaseMutex(); // Release the mutex
                    }
                }).Start();
            }
        }
    
        public static void UseSemaphore()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                {
                    semaphore.WaitOne(); // Acquire a semaphore slot
                    try
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered semaphore.");
                        counter++;
                        Console.WriteLine($"Counter: {counter}");
                        Thread.Sleep(100);
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} exiting semaphore.");
                    }
                    finally
                    {
                        semaphore.Release(); // Release the semaphore slot
                    }
                }).Start();
            }
        }
    
        public static void UseInterlocked()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} incrementing counter.");
                    Interlocked.Increment(ref counter);
                    Console.WriteLine($"Counter: {counter}");
                    Thread.Sleep(100);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed.");
                }).Start();
            }
        }
    }
    

Concurrent File
---------------

Related Topics
--------------

Explore related concepts to expand your knowledge

[Design Pattern Strategy](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Mastery%3A%20A%20Comprehensive%20Guide%20and%20want%20to%20learn%20more%20about%20Design%20Pattern%20Strategy&depth=essentials&id=&format=guide)[Plugin System Exercise](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Mastery%3A%20A%20Comprehensive%20Guide%20and%20want%20to%20learn%20more%20about%20Plugin%20System%20Exercise&depth=essentials&id=&format=guide)

Dive Deeper
-----------

Take a deeper dive into specific areas

[Interfaces Multiple Inheritance](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Mastery%3A%20A%20Comprehensive%20Guide%20and%20want%20to%20dive%20deeper%20into%20Interfaces%20Multiple%20Inheritance&depth=detailed&id=&format=guide)[OOP Deep Dive](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Mastery%3A%20A%20Comprehensive%20Guide%20and%20want%20to%20dive%20deeper%20into%20OOP%20Deep%20Dive&depth=detailed&id=&format=guide)