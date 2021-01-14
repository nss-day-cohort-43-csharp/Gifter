import React from 'react';
import { Card, CardBody, CardImg } from 'reactstrap';

const Post = ({ post }) => {
  return (
    <Card className="mt-4">
      <p className="text-left px-2">Posted by {post.userProfile.name}</p>
      <CardImg top src={post.imageUrl} alt={post.title}/>
      <CardBody>
        <p>
          <strong>{post.title}</strong>
        </p>
        <p>{post.caption}</p>
      </CardBody>
    </Card>
  );
};

export default Post;