using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{

    //Creamos una clase para el nodo
    internal class LDCNode
    {
        //Creamos la estructura que va a contener los nodos
        //Dato del nodo entero
        internal int data;

        //Nodo siguiente=nulo 
        internal LDCNode next;

        //Nodo atras
        internal LDCNode back;



        //Declaramos metodo get(obtener) retorna datos, metodo set(colocar) datos=valor
        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        //Declaramos metodo get(obtener) retorna nodo siguiente, metodo set(colocar) siguiente=valor 
        public LDCNode Next
        {
            get { return next; }
            set { next = value; }
        }
        //Encapsula 
        //Declaramos metodo get(obtener) retorna nodo atras, metodo set(colocar) atras=valor
        public LDCNode Back
        {
            get { return back; }
            set { back = value; }
        }
        //Se crea un constructor para indicarle el valor de las variables data = entero  y next= null
        //Constructor
        public LDCNode(int d)
        {
            data = d;
            next = null;
        }
    }
    //Creamos una clase para lista doblemente enlazada circular
    //Que significa que sea una Lista de Doblemente enlazadas circular?, 
    //Significa que puede recorrer los valores desde el primer nodo hasta el ultimo y diseversa (doble) del ultimo hasta el primero de manera infinita.
    // 3, 5, 6, 7, 9, 1, 12, 34, 25, 30
    internal class CircularDoublyLinkedList 
    {

        //Variable de la cabeza (Primer valor de la lista)
        //private LDENode head = new LDENode();
        internal LDCNode head;

        //Variable ultima(Ultimo valor de la lista)
        internal LDCNode last;

        //Variable nodo
        internal int n;

        internal void Lista()
        {
            head = null;
            last = null;
        }
        //Lista Doblemente Enlazada ------Creacion de Nodo nuevo
        internal CircularDoublyLinkedList ()
        {
           // indicarle que el numero de la lista empieza en 0
            this.n = 1;
        }

        //LCD - 3, 5, 6, 7, 9, 1, 12, 34, 25, 30
        //Primero=null   Ultimo=null    nuevo
        //Insertamos nodos a una lista
        //Creamos una inserción del nuevo nodo de enfrente y al final concatenamos para que pueda leer toda la lista 
        internal void InsertFront(int new_data)
        {
            //Declaramos nuevo nodo
            LDCNode newNode = new LDCNode(new_data);
            //Nodo Ejemplo=3
            //Declaramos a la consola que me introduzca nuevo nodo
            Console.Write("\n Ingrese el dato del nuevo nodo: ");
            //Convertimos valor introducido a la consola a valor entero
            newNode.Data = int.Parse(Console.ReadLine());
            //Porque indicamos que la lista no a sido creada por lo tanto no contiene ningun valor
            if (this.head == null)
            {
                // 3, 5, 6, 7, 9, 1, 12, 34, 25, 30
                //Lista doblemente enlazada circular
                //null <------3-------> null

                //Indicamos que el primer nodo de la lista este nuevo
                //Apuntador indicando que Primero=null y eso significa que va apuntar al nodo que le indiquemos en este caso es 3
                //Primero=3
                head = newNode;
                //Como le indicamos que el primero nuevo nodo igualmente hacemos lo mismo con el ultimo nodo
                last = newNode;
                //Despues definir sus apuntadores 
                //Primero=3 
                //...3 --> 3
                //Como ya sabemos que el nodo head es el primero le damos siguiente y posteriormenete se apunta a el mismo
                head.Next = head;
                //tmb contiene un apuntador que lo apunto hasta al ultimo
                head.Back = last;
                // ultimo <---- 3 ----> primero (siempre habra un circulo de ambos partes por eso es circular
                //y andemas porque contiene doble apuntador de (siguiente-next) y (hacia atras-back)    
                //Ya declaramos la cabeza de la lista


            }
            else

            {

                //ahora necesitamos que el ultimo apuntador sea el nuevo
                // 3 --> siguiente --> 5 a donde apunta al nuevo nodo al siguiente
                last.Next = newNode;
                //Indicamos que el nuevo nodo apunte al ultimo 
                // 3 <---5
                newNode.back = last;
                //El nuevo nodo tmb tiene una puntador a siguiente y necesitamos que apunte al primero
                //Indicamos que el apuntador tmb nos indique al primero osea
                // 5 ---> 3
                //Y asi forma un circulo
                newNode.next = head;
                //tmb el ultimo va a tener un apuntador al primero
                //ultimo = 5 (porque es el ultimo nodo que hemos ingresado)
                last = newNode;
                //tmb necesitamos un apuntador, que si estamos en primero que nos dirija al ultimo
                //que si el primero tiene un apuntador atras que nos dirija al ultimo
                // 5 <------3 No apunte asi mismo si no al ultimo
                head.back = last;
                // 3, 5, 6, 7, 9, 1, 12, 34, 25, 30
                //Genera una circunferencia
                //Y contiene 2 apuntadores
                //3<---- 3 ----><---- 5 ----><---- 6 -----><---- 7 ---->3 
                n++;
            }
            Console.Write("\n Nuevo nodo ingresado con exito \n");
            
            /*    
            newNode.next = this.head;
            this.head = newNode;
         */

        }
         

        //Desplegar lista doble circular
        //Creamos un nuevo nodo que se llama actual (present)
        //Metodo para recorer desde el primero hasta el ultimo
        //Metodo desplegar lista
        internal void displaylistPU(int new_present)
        {
            //Declaramos nuevo nodo
            //vamos desde el primer nodo recorriendo la lista
            //1. Creamos un nuevo apuntador llamado actual que hace referencia al primer nodo de la lista el 3
            LDCNode present = new LDCNode(new_present);

            //1.Aqui le estoy indicando que el valor actual sea igual al primero
            //primero=3, actual=3
            present = head;
            //Actual es diferente a null si
            if (present != null)
            {
                do
                {
                    //Imprimo actual dato
                    //Si encuenta datos que me los imprima con esa condicion
                    Console.WriteLine(" " + present.Data);
                    //Imprimira el 3
                    //Nodo apunta al siguiente 3 --->5
                    present = present.next;


                }//actual es diferente al primero, si porque son 3 y 5
                while (present != head);
            }
            else
            {
                Console.WriteLine("\n La lista se encuenta vacia");
            }
            //3<- 3 ->, <- 5 ->,  6, 7, 9, 1, 12, 34, 25, 30
          
        }
        //Desplegar la lista desde el ultimo hacia el primero
        internal void displaylistUP(int new_present)
        {
            //<-<-<-<-<-<-<-<-<-
            LDCNode present = new LDCNode(new_present);
            //Empiece desde el ultimo
            present = last;

            if(present !=null)
            {
                //necesitamos recorerla por eso necesitamos el do, while
                do
                {
                    Console.WriteLine(" " + present.data);
                    //actual dato con apuntador hace atras
                    present = present.Back;
                }
                while (present != last);
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia");
            }
        }

        
        //Nos permite recorrer la lista mientras actual sea diferente de null
        /*   while(present!=null)
           {
               //Mientras vaya recorriendo los nodos, que nos imprima que va encontrando
               Console.WriteLine(" " + present.Data);
               //usamos apuntar atras es el valor que esta destras de el en este caso recorre la lista hacia atras siendo ser 3
               //ultimo hasta el primero
               present = present.Back;
               //hasta que termina la lista en null
           }
       }*/


        //Obtener el ultimo nodo
        //Recurre lista a valor nulo
        //Aqui hacemos referencia para indicarle al nodo de la cabeza(el primero), que antes de el llevara null, para indicarle que antes de el no hay nada, le indicamos que desde ahí comienza la lista como tal

        internal LDCNode getLastNode()
        {
            LDCNode tmp = this.head;
            if (this.isEmpty())
                return null;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }

            return tmp;
        }

        //Aqui hacemos la insercion del nodo con referencia a nulo. y al final concatenamos para que pueda leer toda la lista
        internal void InsertLast(int new_data)
        {
            LDCNode newNode = new LDCNode(new_data);
            //Aqui creamos un if para llamar a un metodo que hace referencia al valor nulo IsEmpty
            if (isEmpty())
            //if(head==null)
            {
                this.head = newNode;
                n++;
                return;

            }

            LDCNode lastNode = this.getLastNode();
            lastNode.next = newNode;

            n++;
        }
        //Metodo que recorre la lista a valor nudo 
        internal bool isEmpty()
        {
            return head == null;
        }
        //Aqui creamos un contador para que cuente los numeros insertados
        internal int count()
        {
            return n;
        }
        //aqui creamos un metodo para eliminar el nodo que le indicamos a cada lista 
        internal void deleteItem(int val)
        {
            Console.Write("\n Favor de ingresar el nodo que deseamos eliminar: ");
            //Convertimos valor introducido a la consola a valor entero
            val = int.Parse(Console.ReadLine());

            if (!isEmpty())
            {
                if (head.data == val)
                {
                    head = head.next;
                    n--;
                }
                else
                {

                    LDCNode prev = this.head;
                    LDCNode curr;
                    while (prev.next != null)
                    {
                        curr = prev.next;
                        if (curr.data == val)
                        {
                            prev.next = curr.next;
                            n--;
                            return;
                        }
                        prev = curr;
                    }
                }
            }
        }
        //Aqui imprimimos(Desplegamos) la lista de los datos de nuestra clase
        internal void printList()
        {
            LDCNode tmp = this.head;
            if (tmp != null)
                Console.WriteLine(tmp.data);
            while (tmp.next != null)
            {
                tmp = tmp.next;
                Console.WriteLine(tmp.data);
            }
        }
    }





//Aqui le indicamos a la clase main que nos haga un recorrido de lista de los nodos y mandamos a llamar el metodo InsertLast para insertar el nodo aleatorio(random) de la lista
 class Program
    {
        static void Main(string[] args)
    {
        CircularDoublyLinkedList  myList = new CircularDoublyLinkedList ();

        Random r = new Random();
        //int[] lala = { 3, 5, 6, 7, 9, 1, 12, 34, 25, 30 };
        for (int i = 0; i < 10; i++)
        {
                //myList.InsertFront(r.Next(0, 30));
                // myList.InsertLast(lala[i]);
                myList.InsertFront(r.Next(0, 10));
            }

        //Indicamos cabeza principal
        LDCNode tmp = myList.head;
        if (tmp != null)
            Console.WriteLine(tmp.data);
        while (tmp.next != null)
        {
            tmp = tmp.next;
            Console.WriteLine(tmp.data);
        }


            //Aqui desplegamos las listas de los nodos, y las eliminaciones de los nudos asi como imprimimos el contados de los nodos
            Console.WriteLine("\n PRIMERO AL ULTIMO");
            myList.displaylistPU(10);
            Console.WriteLine("LA LISTA TIENE " + myList.count() + " ELEMENTOS");

       
            Console.WriteLine("\n ULTIMO AL PRIMERO");
            myList.displaylistUP(10);
            Console.WriteLine("LA LISTA TIENE " + myList.count() + " ELEMENTOS");


            myList.deleteItem(10);
            Console.WriteLine("\n ELEMENTO ELIMINADO " );
            myList.printList();
            /* 

             myList.deleteItem(3);
             Console.WriteLine("Borramos el 3");
             myList.printList();

             myList.deleteItem(9);
             Console.WriteLine("Borramos el 9");

             myList.printList();


         */

            Console.WriteLine("LA LISTA TIENE " + myList.count() + " ELEMENTOS");
            Console.ReadLine();

        }
      }
    }
