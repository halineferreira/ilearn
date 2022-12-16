import React from 'react'
import Search from './../../components/Search'
import { Box, Link } from '@mui/material'
import './style.css'
import result from './../../mock.json'

export function SearchResults() {
  const query = new URLSearchParams(this.props.location.search)
  console.log(query)

  const lista =
    result.teachers.length > 0 ? (
      result.teachers.map((p) => (
        <div className="teacher">
          <p>
            <span className="tName">{p.name} </span>
            <span className="tScore"> {p.score}</span>
            <span className="tDistance">{p.distance}</span>
          </p>
          <p className="tShortDesc">{p.shortDescription}</p>
          <p>
            <span className="tPrice">R${p.price}</span>
            <Link className="tMore" variant="dark" href="/teacher">
              Ver mais
            </Link>
          </p>
        </div>
      ))
    ) : (
      <p>Não foram encontrados professores para a disciplina pesquisada.</p>
    )

  return (
    <div>
      <Search />
      <h1 id="tabelLabel">{result.total} professores de ... </h1>
      <Box
        id="searchResults"
        sx={{
          display: 'grid',
          gap: 1,
          gridTemplateColumns: 'repeat(3, 1fr)',
        }}
      >
        {lista}
      </Box>
    </div>
  )
}
