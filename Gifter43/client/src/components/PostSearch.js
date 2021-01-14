import React, { useState } from 'react';
import {Form, Input} from 'reactstrap';

const PostSearch = ({ onSearch }) => {
  const [searchTerm, setSearchTerm] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch(`/api/posts/search?criterion=${searchTerm}`)
      .then(res => res.json())
      .then(searchResults => onSearch(searchResults));
  }

  return (
    <Form onSubmit={handleSubmit}>
      <Input placeholder="Search by title" onChange={e => setSearchTerm(e.target.value)}/>
    </Form>
  );
};

export default PostSearch;