using Neo4jClient;

namespace Neo4jDemo
{
    public class GraduatedFromRelationship : Relationship<GraduatedFromData>, 
        IRelationshipAllowingSourceNode<Member>,
        IRelationshipAllowingTargetNode<School>
    {
        public static readonly string TypeKey = "GRADUATEDFROM";

        public GraduatedFromRelationship(NodeReference targetNode, 
            GraduatedFromData data)
            : base(targetNode, data)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
