import React, { useEffect, useState } from 'react';
import Post from './Post';
import PostSearch from './PostSearch';

const PostList = () => {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    fetch('/api/posts')
      .then(res => res.json())
      .then(data => setPosts(data));
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          <PostSearch onSearch={setPosts} />
          {posts.map(post => (
            <div key={post.id}>
              <Post post={post} />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default PostList;