

namespace _022423_temp
{
    class Graph
    {
        public static void Main(string[] args)
        {
            List<Vertex> List;

            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Edge e1 = new Edge() { weight = 7 };
            e1.next = b;
            a.ml.Add(e1);
        }
    }
    class Vertex
    {
        public List<Edge> ml = new List<Edge>();
        public string name;
    }
    
    class Edge
    {
        public Vertex next;
        public int weight;
    }
}