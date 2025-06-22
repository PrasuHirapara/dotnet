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
    
C# Intermediate: A Complete Guide
=================================

Concurrent File Processor
-------------------------

Concurrency is crucial for improving application performance, especially when dealing with I/O-bound operations like file processing. This section explores building a concurrent file processor using `Task` and `async/await`.

### Asynchronous File Operations

Leverage `FileStream` with `UseAsync = true` for asynchronous file I/O. This prevents blocking the main thread.

    public async Task ProcessFileAsync(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                // Process the line asynchronously
                await ProcessLineAsync(line);
            }
        }
    }
    
    private async Task ProcessLineAsync(string line)
    {
        // Simulate some work
        await Task.Delay(10);
        Console.WriteLine($"Processed: {line}");
    }
    

### Task Parallelism

Use `Task.Run` or `Task.Factory.StartNew` to offload CPU-bound operations to the thread pool. `Task.Run` is generally preferred for simpler scenarios.

    public async Task ProcessFilesConcurrentlyAsync(List<string> filePaths)
    {
        var tasks = filePaths.Select(filePath => Task.Run(() => ProcessFileAsync(filePath)));
        await Task.WhenAll(tasks);
    }
    

### Data Partitioning

For large files, partition the data into chunks and process each chunk concurrently. This can significantly improve performance.

    public async Task ProcessFileInChunksAsync(string filePath, int chunkSize)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
        using (var reader = new StreamReader(stream))
        {
            char[] buffer = new char[chunkSize];
            int bytesRead;
            while ((bytesRead = await reader.ReadAsync(buffer, 0, chunkSize)) > 0)
            {
                var chunk = new string(buffer, 0, bytesRead);
                await Task.Run(() => ProcessChunkAsync(chunk));
            }
        }
    }
    
    private async Task ProcessChunkAsync(string chunk)
    {
        // Process the chunk of data
        await Task.Delay(5); // Simulate processing
        Console.WriteLine($"Processed chunk: {chunk.Substring(0, Math.Min(20, chunk.Length))}...");
    }
    

### Thread Safety

When multiple threads access shared resources, ensure thread safety using locks, mutexes, or concurrent collections.

    private static readonly object _lock = new object();
    private static int _processedCount = 0;
    
    private async Task ProcessLineThreadSafeAsync(string line)
    {
        // Simulate some work
        await Task.Delay(10);
        lock (_lock)
        {
            _processedCount++;
            Console.WriteLine($"Processed: {line}, Count: {_processedCount}");
        }
    }
    

Advanced LINQ Queries
---------------------

LINQ (Language Integrated Query) provides a powerful way to query and manipulate data. This section explores advanced LINQ techniques.

### Grouping and Aggregation

Use `GroupBy` to group data based on a key and then apply aggregate functions like `Sum`, `Average`, `Min`, and `Max`.

    var students = new List<Student>
    {
        new Student { Name = "Alice", Grade = 90, Class = "A" },
        new Student { Name = "Bob", Grade = 80, Class = "B" },
        new Student { Name = "Charlie", Grade = 95, Class = "A" },
        new Student { Name = "David", Grade = 75, Class = "B" }
    };
    
    var averageGradesByClass = students.GroupBy(s => s.Class)
        .Select(g => new { Class = g.Key, AverageGrade = g.Average(s => s.Grade) });
    
    foreach (var item in averageGradesByClass)
    {
        Console.WriteLine($"Class: {item.Class}, Average Grade: {item.AverageGrade}");
    }
    

### Joins

Use `Join`, `GroupJoin`, and `Zip` to combine data from multiple sequences.

    var employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Alice", DepartmentId = 1 },
        new Employee { Id = 2, Name = "Bob", DepartmentId = 2 }
    };
    
    var departments = new List<Department>
    {
        new Department { Id = 1, Name = "Sales" },
        new Department { Id = 2, Name = "Marketing" }
    };
    
    var employeeDepartments = employees.Join(departments,
        e => e.DepartmentId,
        d => d.Id,
        (e, d) => new { EmployeeName = e.Name, DepartmentName = d.Name });
    
    foreach (var item in employeeDepartments)
    {
        Console.WriteLine($"Employee: {item.EmployeeName}, Department: {item.DepartmentName}");
    }
    

### Subqueries

Use subqueries to filter data based on conditions derived from another query.

    var highGradeStudents = students.Where(s => s.Grade > students.Average(x => x.Grade));
    
    foreach (var student in highGradeStudents)
    {
        Console.WriteLine($"High Grade Student: {student.Name}, Grade: {student.Grade}");
    }
    

### Deferred Execution

Understand that LINQ queries are often executed lazily (deferred execution). This means the query is not executed until the results are enumerated. Use `ToList()` or `ToArray()` to force immediate execution.

    var query = students.Where(s => s.Grade > 85); // Deferred execution
    
    students.Add(new Student { Name = "Eve", Grade = 92, Class = "A" }); // Add a new student
    
    var results = query.ToList(); // Execute the query and materialize the results
    
    foreach (var student in results)
    {
        Console.WriteLine($"Student: {student.Name}, Grade: {student.Grade}");
    }
    

Custom LINQ Operators
---------------------

Extend LINQ with custom operators to perform specific data transformations.

### Extension Methods

Create extension methods for `IEnumerable<T>` to define custom LINQ operators.

    public static class LinqExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
        {
            return source.Skip(Math.Max(0, source.Count() - n));
        }
    }
    

### Using Custom Operators

Use the custom operators in LINQ queries.

    var filteredStudents = students.WhereIf(true, s => s.Grade > 80); // Apply filter
    var lastTwoStudents = students.TakeLast(2); // Take the last two students
    
    foreach (var student in filteredStudents)
    {
        Console.WriteLine($"Filtered Student: {student.Name}, Grade: {student.Grade}");
    }
    
    foreach (var student in lastTwoStudents)
    {
        Console.WriteLine($"Last Student: {student.Name}, Grade: {student.Grade}");
    }
    

### Implementing Custom Logic

Implement custom logic within the extension methods to perform specific data transformations.

    public static class LinqExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
    
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
    
    var page1Students = students.Paginate(1, 2); // Get the first page of students (2 per page)
    
    foreach (var student in page1Students)
    {
        Console.WriteLine($"Page 1 Student: {student.Name}, Grade: {student.Grade}");
    }
    

Working LINQ XML
----------------

LINQ to XML provides a fluent API for querying and manipulating XML data.

### Loading XML

Load XML data from a file or string using `XDocument.Load` or `XDocument.Parse`.

    using System.Xml.Linq;
    
    // Load from file
    XDocument doc = XDocument.Load("students.xml");
    
    // Load from string
    string xmlString = "<Students><Student><Name>Alice</Name><Grade>90</Grade></Student></Students>";
    XDocument docFromString = XDocument.Parse(xmlString);
    

### Querying XML

Use LINQ queries to extract data from the XML document.

    var studentNames = doc.Descendants("Student")
        .Select(s => s.Element("Name").Value);
    
    foreach (var name in studentNames)
    {
        Console.WriteLine($"Student Name: {name}");
    }
    

### Creating XML

Create new XML documents or modify existing ones using the LINQ to XML API.

    XDocument newDoc = new XDocument(
        new XElement("Students",
            new XElement("Student",
                new XElement("Name", "Bob"),
                new XElement("Grade", 85)
            )
        )
    );
    
    newDoc.Save("new_students.xml");
    

### Modifying XML

Modify existing XML elements and attributes.

    XElement studentElement = doc.Descendants("Student").FirstOrDefault();
    if (studentElement != null)
    {
        studentElement.Element("Grade").Value = "95";
        doc.Save("modified_students.xml");
    }
    

LINQ Data Manipulation
----------------------

LINQ can be used to transform and manipulate data in various ways.

### Projection

Use `Select` to project data into a new form.

    var studentNamesAndGrades = students.Select(s => new { s.Name, s.Grade });
    
    foreach (var item in studentNamesAndGrades)
    {
        Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
    }
    

### Filtering

Use `Where` to filter data based on a condition.

    var highGradeStudents = students.Where(s => s.Grade > 85);
    
    foreach (var student in highGradeStudents)
    {
        Console.WriteLine($"High Grade Student: {student.Name}, Grade: {student.Grade}");
    }
    

### Ordering

Use `OrderBy` and `OrderByDescending` to sort data.

    var sortedStudents = students.OrderBy(s => s.Name);
    
    foreach (var student in sortedStudents)
    {
        Console.WriteLine($"Sorted Student: {student.Name}, Grade: {student.Grade}");
    }
    

### Distinct

Use `Distinct` to remove duplicate elements.

    var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
    var distinctNumbers = numbers.Distinct();
    
    foreach (var number in distinctNumbers)
    {
        Console.WriteLine($"Distinct Number: {number}");
    }
    

LINQ Entity Framework
---------------------

LINQ to Entities allows you to query and manipulate data in a database using LINQ syntax.

### Setting up Entity Framework

Install the Entity Framework Core NuGet package and configure the database context.

    // Example using SQLite
    // dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    using Microsoft.EntityFrameworkCore;
    
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=school.db");
        }
    }
    

### Querying Data

Use LINQ to query data from the database.

    using (var context = new SchoolContext())
    {
        var highGradeStudents = context.Students.Where(s => s.Grade > 85).ToList();
    
        foreach (var student in highGradeStudents)
        {
            Console.WriteLine($"Student: {student.Name}, Grade: {student.Grade}");
        }
    }
    

### Adding Data

Add new entities to the database.

    using (var context = new SchoolContext())
    {
        var newStudent = new Student { Name = "Eve", Grade = 92, Class = "A" };
        context.Students.Add(newStudent);
        context.SaveChanges();
    }
    

### Updating Data

Update existing entities in the database.

    using (var context = new SchoolContext())
    {
        var studentToUpdate = context.Students.FirstOrDefault(s => s.Name == "Alice");
        if (studentToUpdate != null)
        {
            studentToUpdate.Grade = 98;
            context.SaveChanges();
        }
    }
    

### Deleting Data

Delete entities from the database.

    using (var context = new SchoolContext())
    {
        var studentToDelete = context.Students.FirstOrDefault(s => s.Name == "Bob");
        if (studentToDelete != null)
        {
            context.Students.Remove(studentToDelete);
            context.SaveChanges();
        }
    }
    

Optimizing LINQ Queries
-----------------------

Optimizing LINQ queries is crucial for improving application performance, especially when dealing with large datasets.

### Avoid N+1 Problem

The N+1 problem occurs when querying related data. Use eager loading (`Include`) or explicit loading (`Load`) to avoid multiple database round trips.

    // N+1 Problem (Inefficient)
    using (var context = new SchoolContext())
    {
        var departments = context.Departments.ToList();
        foreach (var department in departments)
        {
            // This will result in N+1 queries (one query for departments, and N queries for employees)
            var employees = context.Employees.Where(e => e.DepartmentId == department.Id).ToList();
            Console.WriteLine($"Department: {department.Name}, Employee Count: {employees.Count}");
        }
    }
    
    // Eager Loading (Efficient)
    using (var context = new SchoolContext())
    {
        // This will load departments and their related employees in a single query
        var departments = context.Departments.Include(d => d.Employees).ToList();
        foreach (var department in departments)
        {
            Console.WriteLine($"Department: {department.Name}, Employee Count: {department.Employees.Count}");
        }
    }
    

### Use Compiled Queries

Compiled queries can improve performance by caching the query execution plan. However, they are less flexible than regular LINQ queries. This is less relevant in modern EF Core versions as query compilation is handled more efficiently.

    // Example using EF6 (less relevant in EF Core)
    // private static readonly Func<SchoolContext, string, Student> _getStudentByName =
    //     CompiledQuery.Compile((SchoolContext context, string name) =>
    //         context.Students.FirstOrDefault(s => s.Name == name));
    
    // using (var context = new SchoolContext())
    // {
    //     var student = _getStudentByName(context, "Alice");
    //     Console.WriteLine($"Student: {student.Name}, Grade: {student.Grade}");
    // }
    

### Filter Early

Apply filters as early as possible in the query pipeline to reduce the amount of data processed.

    // Inefficient
    var results = students.Where(s => s.Name.StartsWith("A"))
        .Select(s => new { s.Name, s.Grade })
        .ToList();
    
    // Efficient
    var results2 = students.Select(s => new { s.Name, s.Grade })
        .Where(s => s.Name.StartsWith("A"))
        .ToList();
    

### Avoid Client-Side Evaluation

Ensure that LINQ queries are executed on the database server, not on the client. Client-side evaluation can be inefficient, especially for large datasets. Check the generated SQL to confirm.

    // Potentially inefficient (client-side evaluation if ToUpper() is not supported by the database)
    using (var context = new SchoolContext())
    {
        var studentsWithUpperCaseName = context.Students.Where(s => s.Name.ToUpper() == "ALICE").ToList();
    }
    

Data Analysis Tool
------------------

Building a data analysis tool involves processing and analyzing data from various sources.

### Data Acquisition

Acquire data from files, databases, or APIs.

    // Example: Reading data from a CSV file
    using (var reader = new StreamReader("data.csv"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(',');
            // Process the values
        }
    }
    

### Data Transformation

Transform the data into a suitable format for analysis.

    // Example: Converting string data to numerical data
    var grades = new List<string> { "90", "80", "95" };
    var numericalGrades = grades.Select(g => int.Parse(g)).ToList();
    

### Data Analysis

Perform statistical analysis, data mining, and visualization.

    // Example: Calculating the average grade
    double averageGrade = numericalGrades.Average();
    Console.WriteLine($"Average Grade: {averageGrade}");
    

### Data Visualization

Visualize the data using charts and graphs. Consider using libraries like OxyPlot or ScottPlot.

    // Example using OxyPlot (requires NuGet package)
    // dotnet add package OxyPlot.Core
    // dotnet add package OxyPlot.WindowsForms
    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.WindowsForms;
    
    var plotModel = new PlotModel { Title = "Student Grades" };
    var lineSeries = new LineSeries { Title = "Grades" };
    for (int i = 0; i < numericalGrades.Count; i++)
    {
        lineSeries.Points.Add(new DataPoint(i, numericalGrades[i]));
    }
    plotModel.Series.Add(lineSeries);
    
    var plotView = new PlotView { Model = plotModel };
    // Add plotView to your form or window
    

Reflection Inspect Types
------------------------

Reflection allows you to inspect and manipulate types at runtime.

### Getting Type Information

Use `typeof` or `GetType` to get a `Type` object.

    Type studentType = typeof(Student);
    Student student = new Student();
    Type studentType2 = student.GetType();
    

### Inspecting Members

Use `GetMembers`, `GetFields`, `GetProperties`, and `GetMethods` to inspect the members of a type.

    var members = studentType.GetMembers();
    foreach (var member in members)
    {
        Console.WriteLine($"Member: {member.Name}, Type: {member.MemberType}");
    }
    
    var properties = studentType.GetProperties();
    foreach (var property in properties)
    {
        Console.WriteLine($"Property: {property.Name}, Type: {property.PropertyType}");
    }
    

### Accessing Attributes

Use `GetCustomAttributes` to access attributes applied to a type or member.

    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
    
    public class Student
    {
        [DisplayName(Name = "Student Name")]
        public string Name { get; set; }
        public int Grade { get; set; }
    }
    
    var nameProperty = studentType.GetProperty("Name");
    var displayNameAttribute = (DisplayNameAttribute)nameProperty.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
    
    if (displayNameAttribute != null)
    {
        Console.WriteLine($"Display Name: {displayNameAttribute.Name}");
    }
    

Dynamic Method Invocation
-------------------------

Reflection allows you to invoke methods dynamically at runtime.

### Creating an Instance

Create an instance of a type using `Activator.CreateInstance`.

    Type studentType = typeof(Student);
    object student = Activator.CreateInstance(studentType);
    

### Getting a Method

Get a `MethodInfo` object for the method you want to invoke.

    MethodInfo getNameMethod = studentType.GetMethod("GetName"); // Assuming Student has a GetName method
    

### Invoking the Method

Invoke the method using `MethodInfo.Invoke`.

    // Assuming GetName returns a string
    string name = (string)getNameMethod.Invoke(student, null);
    Console.WriteLine($"Name: {name}");
    

### Handling Parameters

Pass parameters to the method when invoking it.

    MethodInfo setGradeMethod = studentType.GetMethod("SetGrade"); // Assuming Student has a SetGrade(int grade) method
    setGradeMethod.Invoke(student, new object[] { 95 });
    

Attributes Metadata Usage
-------------------------

Attributes provide a way to add metadata to code elements.

### Defining Attributes

Create custom attributes by inheriting from `Attribute`.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
    

### Applying Attributes

Apply attributes to classes, methods, properties, etc.

    [Author(Name = "Alice", Version = "1.0")]
    public class Student
    {
        [DisplayName(Name = "Student Name")]
        public string Name { get; set; }
        public int Grade { get; set; }
    }
    

### Reading Attributes

Read attribute metadata using reflection.

    Type studentType = typeof(Student);
    var authorAttribute = (AuthorAttribute)studentType.GetCustomAttributes(typeof(AuthorAttribute), false).FirstOrDefault();
    
    if (authorAttribute != null)
    {
        Console.WriteLine($"Author: {authorAttribute.Name}, Version: {authorAttribute.Version}");
    }
    

Reflection Dynamic Programming
------------------------------

Reflection can be used to create dynamic and flexible applications.

### Dynamic Object Creation

Create objects dynamically based on configuration or user input.

    string typeName = "MyNamespace.MyClass"; // Get type name from configuration
    Type type = Type.GetType(typeName);
    object instance = Activator.CreateInstance(type);
    

### Dynamic Method Generation

Generate methods dynamically using `DynamicMethod` (requires more advanced knowledge of IL).

    // Example (simplified): Creating a dynamic method that adds two integers
    // Requires System.Reflection.Emit
    // AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
    // AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    // ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
    // TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);
    // MethodBuilder methodBuilder = typeBuilder.DefineMethod("Add", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new Type[] { typeof(int), typeof(int) });
    // ILGenerator ilGenerator = methodBuilder.GetILGenerator();
    // ilGenerator.Emit(OpCodes.Ldarg_0);
    // ilGenerator.Emit(OpCodes.Ldarg_1);
    // ilGenerator.Emit(OpCodes.Add);
    // ilGenerator.Emit(OpCodes.Ret);
    // Type dynamicType = typeBuilder.CreateType();
    // MethodInfo addMethod = dynamicType.GetMethod("Add");
    // int result = (int)addMethod.Invoke(null, new object[] { 5, 3 });
    // Console.WriteLine($"Result: {result}");
    

### Plugin Architecture

Implement a plugin architecture using reflection to load and execute plugins dynamically.

    // Load plugins from a directory
    string pluginDirectory = "Plugins";
    string[] pluginFiles = Directory.GetFiles(pluginDirectory, "*.dll");
    
    foreach (string pluginFile in pluginFiles)
    {
        Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
        foreach (Type type in pluginAssembly.GetTypes())
        {
            if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                plugin.Execute();
            }
        }
    }
    

Dynamic Objects ExpandoObject
-----------------------------

`ExpandoObject` allows you to add and remove members dynamically at runtime.

### Creating an ExpandoObject

Create an instance of `ExpandoObject`.

    dynamic person = new ExpandoObject();
    

### Adding Members

Add members to the `ExpandoObject` dynamically.

    person.Name = "Alice";
    person.Age = 30;
    

### Accessing Members

Access members of the `ExpandoObject` using dynamic syntax.

    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    

### Using with JSON

`ExpandoObject` is often used with JSON serialization and deserialization.

    // Example using Newtonsoft.Json (requires NuGet package)
    // dotnet add package Newtonsoft.Json
    using Newtonsoft.Json;
    
    string json = JsonConvert.SerializeObject(person);
    Console.WriteLine($"JSON: {json}");
    
    dynamic deserializedPerson = JsonConvert.DeserializeObject<ExpandoObject>(json);
    Console.WriteLine($"Deserialized Name: {deserializedPerson.Name}");
    

Configuration System Building
-----------------------------

Building a configuration system involves reading and managing application settings.

### Configuration Files

Use configuration files (e.g., `appsettings.json`) to store application settings.

    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*",
      "MySetting": "MyValue"
    }
    

### Reading Configuration

Read configuration settings using `IConfiguration` (requires `Microsoft.Extensions.Configuration` and related packages).

    // dotnet add package Microsoft.Extensions.Configuration
    // dotnet add package Microsoft.Extensions.Configuration.Json
    using Microsoft.Extensions.Configuration;
    
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    
    IConfiguration configuration = builder.Build();
    
    string mySetting = configuration["MySetting"];
    Console.WriteLine($"MySetting: {mySetting}");
    

### Configuration Sections

Use configuration sections to organize settings.

    {
      "MySection": {
        "Setting1": "Value1",
        "Setting2": "Value2"
      }
    }
    

    string setting1 = configuration["MySection:Setting1"];
    Console.WriteLine($"Setting1: {setting1}");
    

### Binding to Objects

Bind configuration sections to objects.

    public class MySettings
    {
        public string Setting1 { get; set; }
        public string Setting2 { get; set; }
    }
    
    var mySettings = new MySettings();
    configuration.GetSection("MySection").Bind(mySettings);
    
    Console.WriteLine($"Setting1: {mySettings.Setting1}");
    

Dynamic Plugin Loader
---------------------

A dynamic plugin loader allows you to load and execute plugins at runtime.

### Plugin Interface

Define an interface that all plugins must implement.

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        void Execute();
    }
    

### Plugin Discovery

Discover plugins by searching for DLL files in a directory.

    string pluginDirectory = "Plugins";
    string[] pluginFiles = Directory.GetFiles(pluginDirectory, "*.dll");
    

### Plugin Loading

Load plugins using `Assembly.LoadFrom`.

    foreach (string pluginFile in pluginFiles)
    {
        Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
        foreach (Type type in pluginAssembly.GetTypes())
        {
            if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                Console.WriteLine($"Loaded plugin: {plugin.Name}");
                plugin.Execute();
            }
        }
    }
    

### Dependency Injection

Use dependency injection to provide dependencies to plugins.

    // Example using Microsoft.Extensions.DependencyInjection (requires NuGet package)
    // dotnet add package Microsoft.Extensions.DependencyInjection
    using Microsoft.Extensions.DependencyInjection;
    
    public class PluginHost
    {
        private readonly IServiceProvider _serviceProvider;
    
        public PluginHost(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    
        public void LoadPlugins(string pluginDirectory)
        {
            string[] pluginFiles = Directory.GetFiles(pluginDirectory, "*.dll");
    
            foreach (string pluginFile in pluginFiles)
            {
                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
                foreach (Type type in pluginAssembly.GetTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        // Resolve dependencies using the service provider
                        IPlugin plugin = (IPlugin)_serviceProvider.GetRequiredService(type);
                        Console.WriteLine($"Loaded plugin: {plugin.Name}");
                        plugin.Execute();
                    }
                }
            }
        }
    }
    
    // Configure services
    var services = new ServiceCollection();
    // Register plugins as services (e.g., using AddTransient)
    // services.AddTransient<MyPlugin>();
    
    var serviceProvider = services.BuildServiceProvider();
    
    var pluginHost = new PluginHost(serviceProvider);
    pluginHost.LoadPlugins("Plugins");
    

Effective Unit Tests
--------------------

Writing effective unit tests is crucial for ensuring code quality.

### Testable Code

Write code that is easy to test. Avoid tight coupling and dependencies on external resources.

### Arrange, Act, Assert

Follow the Arrange, Act, Assert pattern in your unit tests.

*   **Arrange:** Set up the test environment.
*   **Act:** Execute the code under test.
*   **Assert:** Verify the results.

    [Fact]
    public void Student_GetName_ReturnsCorrectName()
    {
        // Arrange
        var student = new Student { Name = "Alice" };
    
        // Act
        string name = student.Name;
    
        // Assert
        Assert.Equal("Alice", name);
    }
    

### Test Coverage

Aim for high test coverage to ensure that most of your code is tested. Use code coverage tools to measure coverage.

### Test Naming

Use clear and descriptive test names.

    // Good
    [Fact]
    public void Student_Grade_SetValidGrade_ReturnsGrade() { ... }
    
    // Bad
    [Fact]
    public void Test1() { ... }
    

Mocking Frameworks Implementation
---------------------------------

Mocking frameworks allow you to isolate the code under test by replacing dependencies with mock objects.

### Using Moq

Moq is a popular mocking framework for C#. (Requires NuGet package: `dotnet add package Moq`)

    using Moq;
    
    public interface IStudentService
    {
        Student GetStudent(int id);
    }
    
    public class StudentController
    {
        private readonly IStudentService _studentService;
    
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
    
        public string GetStudentName(int id)
        {
            Student student = _studentService.GetStudent(id);
            return student?.Name;
        }
    }
    
    [Fact]
    public void StudentController_GetStudentName_ReturnsStudentName()
    {
        // Arrange
        var mockStudentService = new Mock<IStudentService>();
        mockStudentService.Setup(s => s.GetStudent(1))
            .Returns(new Student { Id = 1, Name = "Alice" });
    
        var controller = new StudentController(mockStudentService.Object);
    
        // Act
        string name = controller.GetStudentName(1);
    
        // Assert
        Assert.Equal("Alice", name);
        mockStudentService.Verify(s => s.GetStudent(1), Times.Once); // Verify that GetStudent was called once
    }
    

### Mocking Interfaces and Abstract Classes

Mocking frameworks can mock interfaces and abstract classes.

### Verifying Interactions

Verify that methods were called with the expected arguments and number of times.

Test-Driven Development (TDD)
-----------------------------

Test-Driven Development (TDD) is a development process where you write tests before writing the code.

### Red-Green-Refactor

Follow the Red-Green-Refactor cycle:

*   **Red:** Write a failing test.
*   **Green:** Write the minimum amount of code to make the test pass.
*   **Refactor:** Refactor the code to improve its design and maintainability.

### Benefits of TDD

*   Improved code quality
*   Reduced defects
*   Better design
*   Increased confidence

### Example TDD Cycle

1.  **Red:** Write a test for a `Calculator` class that adds two numbers. The test should fail because the `Calculator` class doesn't exist yet.
2.  **Green:** Write the `Calculator` class with an `Add` method that returns 0. The test will now pass (but the implementation is not correct).
3.  **Refactor:** Refactor the `Add` method to correctly add two numbers. The test should still pass.

Unit Testing Debugging
----------------------

Debugging unit tests involves identifying and fixing issues in your tests.

### Debugging Tools

Use the debugger to step through your tests and inspect variables.

### Test Failures

Analyze test failures to understand the root cause of the problem.

### Isolating Issues

Isolate issues by writing smaller, more focused tests.

### Common Issues

*   Incorrect assertions
*   Setup issues
*   Mocking errors

Complex Applications Debugging
------------------------------

Debugging complex applications requires a systematic approach.

### Logging

Use logging to track the flow of execution and identify potential issues.

### Debugging Tools

Use the debugger to step through the code and inspect variables.

### Breakpoints

Set breakpoints at strategic locations to pause execution and examine the state of the application.

### Remote Debugging

Use remote debugging to debug applications running on remote servers or devices.

### Memory Profiling

Use memory profiling tools to identify memory leaks and other memory-related issues.

C# Code Profiling
-----------------

Code profiling helps you identify performance bottlenecks in your code.

### Profiling Tools

Use profiling tools like Visual Studio Profiler or dotTrace to measure the performance of your code.

### Identifying Bottlenecks

Identify the methods and code sections that consume the most time.

### Optimization Techniques

Apply optimization techniques to improve the performance of your code.

*   Algorithm optimization
*   Caching
*   Asynchronous programming
*   Memory management

Asynchronous API Testing
------------------------

Testing asynchronous APIs requires special considerations.

### Async Test Methods

Use `async` test methods to properly test asynchronous code.

    [Fact]
    public async Task MyAsyncTest_ReturnsResult()
    {
        // Arrange
        // Act
        var result = await MyAsyncMethod();
    
        // Assert
        Assert.NotNull(result);
    }
    

### Task Completion

Ensure that asynchronous operations complete before asserting results.

### Mocking Asynchronous Methods

Mock asynchronous methods using mocking frameworks.

    var mockService = new Mock<IMyService>();
    mockService.Setup(s => s.MyAsyncMethod())
        .ReturnsAsync("Result");
    
