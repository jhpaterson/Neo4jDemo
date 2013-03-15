using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            client.Connect();

            #region CREATE
            //// Create entities
            //var member1 = client.Create(new Member() { Name = "Fernando" });
            //var member2 = client.Create(new Member() { Name = "Felipe" });
            //var member3 = client.Create(new Member() { Name = "Jenson" });
            //var member4 = client.Create(new Member() { Name = "Checo" });
            //var member5 = client.Create(new Member() { Name = "Nico" });

            //var sch1 = client.Create(new School() { Name = "GCU" });
            //var sch2 = client.Create(new School() { Name = "MIT" });
            //var sch3 = client.Create(new School() { Name = "UCLA" });

            //var cit1 = client.Create(new City() { Name = "Glasgow" });
            //var cit2 = client.Create(new City() { Name = "New York" });
            //var cit3 = client.Create(new City() { Name = "Los Angeles" });
            //var cit4 = client.Create(new City() { Name = "Cambridge" });

            //// Create relationships
            //client.CreateRelationship(member1, new ConnectedToRelationship(member2));
            //client.CreateRelationship(member3, new ConnectedToRelationship(member4));
            //client.CreateRelationship(member4, new ConnectedToRelationship(member5));
            //client.CreateRelationship(member1, new ConnectedToRelationship(member5));

            //client.CreateRelationship(member1, new GraduatedFromRelationship(sch1, new GraduatedFromData(2001)));
            //client.CreateRelationship(member2, new GraduatedFromRelationship(sch2, new GraduatedFromData(2002)));
            //client.CreateRelationship(member3, new GraduatedFromRelationship(sch1, new GraduatedFromData(2003)));
            //client.CreateRelationship(member4, new GraduatedFromRelationship(sch3, new GraduatedFromData(2004)));

            //client.CreateRelationship(member1, new LivesInRelationship(cit1));
            //client.CreateRelationship(member2, new LivesInRelationship(cit2));
            //client.CreateRelationship(member3, new LivesInRelationship(cit2));
            //client.CreateRelationship(member4, new LivesInRelationship(cit3));
            //client.CreateRelationship(member5, new LivesInRelationship(cit4));

            //client.CreateRelationship(sch1, new LocatedInRelationship(cit1));
            //client.CreateRelationship(sch2, new LocatedInRelationship(cit4));
            //client.CreateRelationship(sch3, new LocatedInRelationship(cit3));
            #endregion

            // get node reference for School GCU 
            // see this post for details of indexing: http://stackoverflow.com/questions/14358797/working-with-index-in-neo4j
            Node<School> myNode = client.QueryIndex<School>(
                "node_auto_index", IndexFor.Node, "Name:GCU").FirstOrDefault();

            // members who graduated from GCU
            var query = client.Cypher
                               //.Start("school",(NodeReference)6)
                               .Start("school", myNode.Reference)
                               .Match("member-[:GRADUATEDFROM]->school")
                               .Return<Node<Member>>("member");

            var result = query.Results.ToList();

            Console.WriteLine("Members who graduated from GCU:");
            foreach (Node<Member> m in result)
            {
                Console.WriteLine(m.Data.Name);
            }

            // members connected to Nico

            Console.ReadLine();
        }
    }
}
