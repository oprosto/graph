using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(DijkstraDisplay))]
public class DiykstraMethod : MonoBehaviour
{
    private DijkstraDisplay _display;
    private Dictionary<int, Vertex> _parents;
    private Dictionary<int, double> _distance;
    
    private void Start() 
    {
        _display = GetComponent<DijkstraDisplay>();
    }
    public double startDijkstra(Vertex from, Vertex to) 
    {
        return findDaWay(from, to);
    }
    private double findDaWay(Vertex start, Vertex end)
    {
        int MAX = DataBase.GetAmountOfVertex();
        List<Vertex> S = new List<Vertex>(DataBase.vertices);
        _distance = new Dictionary<int, double>(MAX);
        _parents = new Dictionary<int, Vertex>(MAX);
        S.Remove(start);
        _distance[start.GetId()] = 0;
        foreach (Vertex vertex in S)
        {
            if (start == vertex)
                continue;

            Edge[] goodEdges = start.GetEdges().Where(x => x.GetId() == vertex.GetId()).ToArray();
            if (goodEdges.Length != 0)
            {
                _distance[vertex.GetId()] = goodEdges[0].GetValue();
                _parents[vertex.GetId()] = start;
            }
            else
            {
                _distance[vertex.GetId()] = double.MaxValue;
                _parents[vertex.GetId()] = null;
            }
        }
        while (S.Count != 0)
        {
            Vertex choosen = null;
            double min = double.MaxValue;
            foreach (var el in S)
            {
                if (_distance[el.GetId()] <= min)
                {
                    min = _distance[el.GetId()];
                    choosen = el;
                }
            }

            S.Remove(choosen);
            foreach (var el in S)
            {
                List<Edge> edges = choosen.GetEdges().Where(x => x.GetId() == el.GetId()).ToList();
                if (edges.Count == 0)
                    continue;
                double value = edges.Min().GetValue();
                if (_distance[el.GetId()] > _distance[choosen.GetId()] + value)
                {
                    _distance[el.GetId()] = _distance[choosen.GetId()] + value;
                    _parents[el.GetId()] = choosen;
                }
            }
        }
        if (_distance[end.GetId()] != double.MaxValue)
            FindWay(start, end);
        return _distance[end.GetId()];

    }
    private void FindWay(Vertex start, Vertex end) 
    {
        List<Edge> way = new List<Edge>();
        Vertex currVertex = end;
        Edge currEdge = null;
        while (currVertex != start)
        {
            currEdge = _parents[currVertex.GetId()].GetEdges().Where(edge => edge.GetId() == currVertex.GetId()).First();
            currVertex =_parents[currVertex.GetId()];
            way.Add(currEdge);
        }
        way.Reverse();

        _display.DisplayWay(way);
    }
   
}
