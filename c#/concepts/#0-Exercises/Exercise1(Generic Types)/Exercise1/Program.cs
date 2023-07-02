//Program Name: Exercise 1
//Purpose: this this is program.cs file of the entire exercies 1 
//Programmer: Hassan Ihsan
//Date:

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            // List<string> d = new();

            // d.Clear();

            GenericList<Student> s1 = new();
            GenericList<Professor> p1 = new();


            Student hassan = new Student("hassan", "ihsan", "emauk");
            Student yuki = new Student("yuki", "kamiya", "emauk");
            Student hiro = new Student("hiro", "kamiya", "emauk");



            s1.Add(hassan);
            s1.Add(yuki);
            s1.Add(hiro);

            foreach (var item in s1)
            {
                Console.WriteLine("item of GenList<student> (foreach) = " + item);
            }

            Console.WriteLine(  );


            Professor p11 = new Professor("pro", "man", "em", DateTime.Now);
            Professor p12 = new Professor("pro1", "man1", "em", DateTime.Now);
            Professor p13 = new Professor("pro2", "man2", "em", DateTime.Now);

            p1.Add(p11);
            p1.Add(p12);
            p1.Add(p13);

            foreach (var item in p1)
            {
                Console.WriteLine("item of GenList<Proffessor> (foreach) = " + item);
            }


            Console.WriteLine();

            Console.WriteLine("testing clear method");
            s1.Clear();

            foreach (var item in s1)
            {
                Console.WriteLine("item of GenList<student> after clear (foreach) = " + item);
            }


            Console.WriteLine();

            Console.WriteLine("testing getitem method");
            Console.WriteLine(p1.GetItem(2));


            Console.WriteLine();
            Console.WriteLine("test remove method");

            // p1.Remove(1);


            //foreach (var item in p1)
            //{
            //    Console.WriteLine("item of GenList<Proffessor> after remove (foreach) = " + item);
            //}

            Console.WriteLine();
            Console.WriteLine("test insert");

            p1.Insert(1, p13);
            //p1[1] = p13; still can do this

            foreach (var item in p1)
            {
                Console.WriteLine("item of GenList<Proffessor> after remove (foreach) = " + item);
            }

        }
    }
}