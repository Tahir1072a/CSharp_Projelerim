using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.Tree
{
    /// <summary>
    /// Tüm binary Treeler için genle metotları içerir.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class BinaryTree<T> where T : IComparable
    {
        public static List<Node<T>> list { get; private set; } = new List<Node<T>>();
        private static bool IsFirstCall = true;
        /// <summary>
        /// Verilen kökte bulunan nodeları InOrder(L-D-R) prensibi ile bir listeye aktararak return eder. Recursive Bir yaklaşım uygular.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static List<Node<T>> InOrder(Node<T> root)
        {
            //Kısaca bu recursive yaklaşımda önce ilgili node'un sol tarafı daha sonra kökün değeri ve daha sonra da kökün sağ tarafı ile ilgilenir.
            if (root != null)
            {
                InOrder(root.Left);  //İlk önce en sol değere kadar gider. Null değere ulaştığında return eder.
                list.Add(root);      //Burada veriyi  ekler. En sol değere ulaştık ve bunu ekledik.
                InOrder(root.Right); //Burada ise ilgili değerin sağ tarafı için aynı işlemi yapar.
            }
            return list;
        }
        /// <summary>
        /// Kendisine parametre olarak verilen kökü PreOrder(D-L-R)  prensibi ile dolaşır ve bunları bir listeye ekler. Daha sonra return eder.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static List<Node<T>> PreOrder(Node<T> root)
        {
            //Temel yaklaşım gelen node için ilgili değeri listeye eklemektir. Recursive çağrılar ile önce sol sonra sağ taraf gezilir. Ancak her zaman önce ilgili kökteki data listeye eklenir.
            if (root != null)
            {
                list.Add(root);   // İlgili kökteki değeri ekler. Her recursive çağrıda bunun yapıldığı unutulmamalıdır.
                PreOrder(root.Left); // Daha sonra ilgili kökün sol tarafı için recursive çağrılara başlar.
                PreOrder(root.Right); // Sol taraf için recursive çağrılara başlar.
            }
            return list;
        }
        /// <summary>
        /// PostOrder (L-R-D) prensibi ile parametre olarak verilen kökteki node değerlerini bir listeye ekleyip return eder.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static List<Node<T>> PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);  //Önce sol taraf için recursive çağrılara başlar.
                PostOrder(root.Right); //Sol taraf kalmayınca ilgili kökün sağ tarafına geçer.
                list.Add(root);  //Sağ taraf için de yapıalcak recursive çağrı kalmadığında ilgili değeri ekler.
            }
            return list;
        }
        /// <summary>
        /// Non-Recursive bir metottur. Recursive oalrak çalışan InOrder metodu ile aynı işi farklı bir algoritma ile yapar. Stackoverflow olaylarını engellemiş olur.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> InOrderIter(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            var S = new Stack<Node<T>>();  //Stack yapısını kullanmakdaki mantık ağacın içine daldıkça geriye doğru dönebilmek içindir. Çift düğümlü linked listeki ikinci düğüm olarak düşünülebilir.
            Node<T> currentNode = root;  //Ağaç yapısı currentNode adlı bir değişken üzerinden gezilecektir. Böylelikle root üzerinde oynama yapılmamış olur.
            bool done = false; //Kontrol değişkenidir. Zorunlu değildir, break kullanılarakta döngüden çıkılabilir.
            while (!done)
            {
                if (currentNode != null) { S.Push(currentNode); currentNode = currentNode.Left; } // CurrentNode null olana kadar sola gider. Her gidişi yaparken denk geldiği nodeları stack yapısına ekler. Burada ekleme derine indikçe geriye dönüş yapabilmek içindir.
                else
                {
                    if (S.Count == 0) //Eğer stack yapısının içinde herhangi bir node kalmamışsa ve buraya girmiş ise bu demek oluyorki ağaçtaki tüm nodelar listeye aktarılmıştır. Çünkü her zaman solu kontrol eder ancak aşağıda en sola geçince listeye ekleme işlemi yaparak sağa geçer. Hem stack null olması hem de currentNode null olması demek en sağdaki değerde listeye eklenmiş demektir. En sağın sağı nulldır ve en sağdaki değerden sonra stack de değer kalmamıştır.
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop(); //Stackdeki en üsteki node çıkartılır ve şuan da null olan current node atanır.
                        list.Add(currentNode); //Bu en soldaki değer olduğu için listeye eklmeeye yapılır.
                        currentNode = currentNode.Right; //Daha sonra ilgil ideğerin sağ tarfı için aynı işlemlerin uygulanması adına currentNode sağ tarafa geçirilir.
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// PreOrder yaklaşımının recursive olmayan bir algoritma ile uygulanmasıdır.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Node<T>> PreOrderIte(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            if (root == null) throw new Exception(); //Gelen node null ise hata verir. Boş bir ağacı gezemessin :D.
            Stack<Node<T>> S = new Stack<Node<T>>(); //Derinlere inerken yolumuzu kaybetmemk için stack yapısını kullanırız.
            S.Push(root); //Root stak'e eklenir.
            while (S.Count != 0)
            {
                Node<T> temp = S.Pop(); //Stack içinde bulunan değer çıkartılır ve listeye eklenir. Buradaki mantık Önce Data listeye eklenir Daha sonra stack içine aşağıda sağ ve sol olmak üzere ilgili kökün değerleri sırayla eklenir. Tekrar kod buraya döndüünde stack üstündeki tepe değer root'un sol tarafındaki değer olacaktır.Bu işlem n(Ağaç içindeki eleman sayısı) kadar tekrarlanır. Kodu tam anlamak için stack yapısını çizebilir ve eklemlere bakabilirsin. 
                list.Add(temp);
                if (temp.Right != null) { S.Push(temp.Right); } //ilgili root'un sağ tarafı dolu ise sağ taraf stack'e eklenir. İlk önce sağ tarafın eklenmesi stack yapısı ile alakalıdır.
                if (temp.Left != null) { S.Push(temp.Left); }
            }
            return list;
        }
        /// <summary>
        /// PostOrder yaklaşımının Non-Recursive bir uygulamasıdır. Ayıptır söylemesi tamamen kendim yazdım :).
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            // 2 tane stack oluşturuyoruz çünkü 2. stack de dönüm noktalarını saklayacağız.
            var S = new Stack<Node<T>>();
            var S2 = new Stack<Node<T>>();
            var currentNode = root; //Başlangıç Node
            while (true)
            {
                if (currentNode != null) { S.Push(currentNode); currentNode = currentNode.Left; } //Ağaçta en son değere kadar gidiyoruz.
                else  //Sooldaki en son değeri bulunca buraya giriyoruz.
                {
                    currentNode = S.Peek(); //Stack içinden elemanı silmeden currentNode ekliyoruz, bu en sondaki eleman oluyor.
                    S2.Push(currentNode); // Artık bu dönüm noktası oluyor çünkü onun sağına bakmamız gerekiyor.
                    if (currentNode.Right != null) { currentNode = currentNode.Right; } //Sağında eleman var ise current sağ tarafa geçiyor.
                    else
                    {
                        //Döngü, S2 içindeki tepe eleman ile S içindeki tepe eleman eşit olduğu sürece döner. 
                        while (S2.Count > 0 && S.Count > 0 && S.Peek() == S2.Peek()) //Eğer dönüm noktasının sağında eleman yok ise döngü koşulna bakıyoruz
                        {
                            list.Add(S2.Pop()); //Eşit elemanı listeye ekliyoruz.
                            S.Pop(); //Diğer listeden de çıkartıyoruz.
                        }
                        if (S.Count == 0) break; //S içinde eleman kalmadıysa işlem bitiyor.
                        currentNode = S.Peek(); //Bir üst elemana geçiş yapıyoruz. 
                        S2.Push(currentNode); //Artık bu eleman bir dönüm noktası çünkü önceden solu kontrol edilmişti.
                        currentNode = currentNode.Right; //Sağ tarafa geçiiş yapıyoruz.
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// LevelOrder yaklaşımı sırayla her derinliği soldan başlamak üzere dolaşır. Bu yaklaşımı uygulayan bir algoritmadır.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            var Q = new Queue<Node<T>>(); //Kuyruk yapısı kullanılır. Diğerlerinden farklıdır dikkat çekerim.
            Q.Enqueue(root); //İlk önce ilk derinilikteki kök kuyruğa eklenir çünkü ilk o çıkacaktır.
            while (Q.Count > 0)
            {
                var temp = Q.Dequeue(); //Root çıkar.
                list.Add(temp);//Listeye eklenir.
                //Daha sonra rootun önce sol sonra sağ değerleri varsa onlar kuyruğa eklenir.
                if (temp.Left != null) { Q.Enqueue(temp.Left); }
                if (temp.Right != null) { Q.Enqueue(temp.Right); }
                //Döngübir kez daha döndüünde kuyruktaki diğer eleman için döner ve onun sağ ve sol değerlerini kuyruğa ekler. Tam anlamak için kuyruk yapısını canlandır veya çiz.
            }
            return list;
        }
        /// <summary>
        /// Parametere olarak verilen kökün derinliğini bulur.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepht(Node<T> root)
        {
            if(root == null) return 0; //Kök null ise derinliği 0'dır.
            int leftDepht = MaxDepht(root.Left); //Önce kökün sol tarafına gider ve orada bir derinlik araması yapar. Dikkat recursive bir çağrıdır.
            int rightDepht = MaxDepht(root.Right); //Kökün sol tarafı için arama bittiğinde sağ tarafına geçer ve orada derinlik bakar.
            //Son olarak kökün sağ ve sol tarfındaki derinliği karşılaştırır. Hangi taraf daha derinse kök kendisinide hesaba katarak +1 yapar ve ilgili değeri return eder.
            return (leftDepht > rightDepht) ? leftDepht + 1 : rightDepht + 1;
        }
        /// <summary>
        /// Parametre olarak verilen kökün(Ağaç yapısının) en derinindeki değeri bulur. Aynı derinlikteki değerler için en sağdaki değeri return eder.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Node<T> DeepstNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null) throw new Exception();

            var Q = new Queue<Node<T>>();
            Q.Enqueue(root);
            while (Q.Count > 0)
            {
                temp = Q.Dequeue();
                if (temp.Left != null)
                    Q.Enqueue(temp.Left);
                if (temp.Right != null)
                    Q.Enqueue(temp.Right);
            }
            return temp;
        }
        public static int NumberOfFullNodes(Node<T> root) => BinaryTree<T>.LevelOrderNonRecursiveTraversal(root).Where(x => (x.Left != null && x.Right != null))
            .ToList().Count;
        public static int NumberOfHalfNodes(Node<T> root) => BinaryTree<T>.LevelOrderNonRecursiveTraversal(root).Where(x => (x.Left == null && x.Right != null) || (x.Left != null && x.Right == null))
            .ToList().Count;
        /// <summary>
        /// Parametre olarak girilen root için yapraklara ulaşım yolarını consala çizdirir.
        /// </summary>
        /// <param name="root"></param>
        public static void PrintPaths(Node<T> root)
        {
            var path = new T[256]; //Bir geçici dizi oluştururz. Boyutu bir yolun alabileceği max boyut oalrak düşünmeliyiz. Öngörü olarak 256 dedik. Bu aslına derinliği ifade eder ve full dolu bir binary ağaç için 2^(256 -1) tane eleman içerdiğini gösterir.
            PrintPaths(root, path, 0); //Console yazdırma ayrı bir metot çağrılarak yapılır.
        }
        /// <summary>
        /// İlgili kökü alır. Ve önceden tanımlanmış bir dizi alır. Daha sonra bir yol uzunluğu bilgisi tutmak için değişken alır.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        /// <param name="pathLenght"></param>
        private static void PrintPaths(Node<T> root, T[] path, int pathLenght = 0)
        {
            if(root == null) return; //Root null ise çizme işlemi yapılamaz.
            path[pathLenght] = root.Value; //Diziye kök değer eklenir.
            pathLenght++; //Dizi indexer'ı bir artar. Count değerini artırmış oluyoruz.

            if(root.Left == null && root.Right == null) //root'un sağı ve solu null ise yaprağa ulaşmışızdır demektir. O zaman yazdırma işlemi başlar. 
            {
                PrintArray(path, pathLenght); 
            }
            else //Yaprağa ulaşılmadıysa recursive çağrılar devam eder.
            {
                //Sol taraf için ayrı sağ taraf için ayrı olmak üzere 2 tane recursive çağrı yapılır.
                PrintPaths(root.Left, path, pathLenght);
                PrintPaths(root.Right, path, pathLenght);
            }
        }
        /// <summary>
        /// Tam olarak yolun console yazdırıldığı metottur.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="len"></param>
        private static void PrintArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine(); //Boşluk bırakmak için...
        }
        /// <summary>
        /// İligli ağaçtaki yaprak sayısını döner.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int NumberOfLeafs(Node<T> root)
        {
            #region Algorithms
            int count = 0; //Yaprak sayısını saymak için kullanılan değikendir.
            if (root == null) return count; //Parametre olarak gelen kök null ise 0 döner. Hata vermez!. 
            var Q = new Queue<Node<T>>(); //Kuyruk yapısı oluşturulur. Ağaç içinde dolaşmak içindir.
            Q.Enqueue(root); 
            while(Q.Count > 0)
            {
                var temp = Q.Dequeue(); //Roottan başlanır.
                if (temp.Left == null && temp.Right == null) //Sağ ve sol null mı kontrol edilir. Null ise bu bir yapraktır.
                    count++;
                //Değil ise ve sadece sol değeri kontrol edilir. Sol değer null değilse sol değeri kuyruğa ekler. Kuyruğa eklneen her değer için bir dolaşım yapıalcaktır.
                if(temp.Left != null)
                {
                    Q.Enqueue(temp.Left);
                }
                //Yukarıdaki aynı işlemi sağ için yapar.
                if(temp.Right != null)
                {
                    Q.Enqueue(temp.Right);
                }
            }
            return count;
            #endregion
            #region Alternatif
            //Daha önceden yazılmış bir fonksiyon kullanılarak yapılan alternatif bir yöntemdir.
            //return BinaryTree<T>.LevelOrderNonRecursiveTraversal(root).Where(p=> (p.Left == null&&p.Right == null)).ToList().Count;
            #endregion
        }
        /// <summary>
        /// PostOrder yaklaşımını kullanrak ağaç içinde gezinme yapan ve recursive algoritma kullanan bir metottur.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> GetListPostOrder(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            return PostOrder(root); // Sadece bir soyutlama yapılmıştır. Amaç genle olarak her metot için kullanılan list değişkeninin içinde bulunan verileri sıfırlamak için kullanılır.
        }
        /// <summary>
        /// InOrder yaklaşımını kullanrak ağaç içinde gezinme yapan ve recursive algoritma kullanan bir metottur.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> GetListInOrder(Node<T> root)
        {
            if (list.Count > 0) ClearList();

            return InOrder(root);
        }
        /// <summary>
        /// PreOrder yaklaşımını kullanrak ağaç içinde gezinme yapan ve recursive algoritma kullanan bir metottur.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Node<T>> GetListPreOrder(Node<T> root)
        {
            if (list.Count > 0) ClearList();
            return PreOrder(root);
        }
        /// <summary>
        /// Geçici listeyi boşaltır.
        /// </summary>
        public static void ClearList() => list.Clear();
    }
}
