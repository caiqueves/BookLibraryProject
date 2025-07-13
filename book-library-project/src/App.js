import React, { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [field, setField] = useState("");
  const [value, setValue] = useState("");
  const [books, setBooks] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 5;

  const searchBooks = async (searchField, searchValue, page) => {
    try {
      const response = await fetch(`https://localhost:7073/BookLibrary/search?field=${searchField}&value=${searchValue}`);
      if (response.ok) {
        const data = await response.json();
        setBooks(data);
      } else {
        setBooks([]);
      }
    } catch (err) {
      alert("Erro ao buscar livros: " + err.message);
    }
  };

  const handleSearch = async () => {
    if (!field || !value) {
    alert("Please select a field and enter a value.");
    return;
    }
    setCurrentPage(1); // volta para página 1
    searchBooks(field, value, 1);
  };

  useEffect(() => {
    if (field && value) {
      searchBooks(field, value, currentPage);
    }
  }, [currentPage]);

  return (
    <div className="container">
      <h1>Books Library</h1>
      <div className="form-box">
        <div className="form-group">
          <label>Search By:</label>
          <select value={field} onChange={(e) => setField(e.target.value)}>
            <option value="">Select</option>
            <option value="author">Author</option>
            <option value="isbn">ISBN</option>
            <option value="status">Status</option>
          </select>
        </div>

        <div className="form-group">
          <label>Search Value:</label>
          <input
            type="text"
            value={value}
            onChange={(e) => setValue(e.target.value)}
            placeholder="Enter search term"
          />
        </div>

        <button className="search-button" onClick={handleSearch}>
          Search
        </button>
      </div>


    <div>
        <h2>Search Results:</h2>
        {books.length === 0 ? (
          <p>No books found.</p>
        ) : (
          <table border="1" cellPadding="5" style={{ borderCollapse: "collapse", width: "100%" }}>
            <thead style={{ backgroundColor: "#ccc" }}>
              <tr>
                <th>Book Title</th>
                <th>Publisher</th>
                <th>Authors</th>
                <th>Type</th>
                <th>ISBN</th>
                <th>Category</th>
                <th>Available Copies</th>
              </tr>
            </thead>
            <tbody>
              {books.map((book) => (
                <tr key={book.bookId}>
                  <td>{book.title}</td>
                  <td>{book.publisher || "N/A"}</td> {/* Se não tiver, pode exibir N/A */}
                  <td>{book.firstName} {book.lastName}</td>
                  <td>{book.type}</td>
                  <td>{book.isbn}</td>
                  <td>{book.category}</td>
                  <td>{(book.totalCopies - book.copiesInUse)}/{book.totalCopies}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

      <div style={{ marginTop: '20px', textAlign: 'center' }}>
        <button
          disabled={currentPage === 1}
          onClick={() => setCurrentPage(prev => Math.max(prev - 1, 1))}
        >
          Previous
        </button>

        <span style={{ margin: '0 10px' }}>Page {currentPage}</span>

        <button
          disabled={books.length < pageSize}
          onClick={() => setCurrentPage(prev => prev + 1)}
        >
          Next
        </button>
      </div>
    </div>
  );
}

export default App;
