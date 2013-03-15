using Neo4jClient;

namespace Neo4jDemo
{

    public class LivesInRelationship : Relationship, IRelationshipAllowingSourceNode<Member>,
        IRelationshipAllowingTargetNode<City>
    {
        public static readonly string TypeKey = "LIVESIN";

        public LivesInRelationship(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }

}