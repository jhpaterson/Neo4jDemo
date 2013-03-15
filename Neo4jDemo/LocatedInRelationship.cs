using Neo4jClient;

namespace Neo4jDemo
{

    public class LocatedInRelationship : Relationship, IRelationshipAllowingSourceNode<School>,
        IRelationshipAllowingTargetNode<City>
    {
        public static readonly string TypeKey = "LOCATEDIN";

        public LocatedInRelationship(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }

}