import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import Post from './Post';

const UserPosts = () => {
  const { userId } = useParams();
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    fetch(`/api/posts/getbyuser/${userId}`)
      .then(res => res.json())
      .then(posts => setPosts(posts));
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {posts.map((post) => (
            <Post key={post.id} post={post} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default UserPosts;