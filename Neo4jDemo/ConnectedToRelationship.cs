using Neo4jClient;

namespace Neo4jDemo
{

    public class ConnectedToRelationship : Relationship, 
        IRelationshipAllowingSourceNode<Member>,
        IRelationshipAllowingTargetNode<Member>
    {
        public static readonly string TypeKey = "CONNECTEDTO";

        public ConnectedToRelationship(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }

}
