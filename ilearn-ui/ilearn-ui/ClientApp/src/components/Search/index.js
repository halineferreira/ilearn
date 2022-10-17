import React from 'react'
import Button from '@mui/material/Button'
import TextField from '@mui/material/TextField'
import './style.css'

const Search = () => {
  return (
    <form id="Search">
      <TextField
        id="subject"
        className="search-input mr-10"
        label="O que você quer aprender?"
        aria-label="O que você quer aprender?"
        variant="outlined"
        sx={{ mr: 1 }}
        size="small"
      />
      <TextField
        id="location"
        className="search-input"
        label="Cidade"
        aria-label="Cidade"
        variant="outlined"
        sx={{ mr: 1 }}
        size="small"
      />
      <Button variant="contained" color="secondary" href="/results">
        Buscar
      </Button>
      <br />
    </form>
  )
}

export default Search
