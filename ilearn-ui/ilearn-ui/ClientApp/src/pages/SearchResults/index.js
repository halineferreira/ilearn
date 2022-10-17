import React, { Component } from 'react'
import Search from './../../components/Search'
import { Box, Link } from '@mui/material'
import './style.css'

export class SearchResults extends Component {
  static displayName = SearchResults.name

  render() {
    const result = {
      teachers: [
        {
          id: 1,
          name: 'Maria',
          score: 4,
          distance: '200m',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 99,
        },
        {
          id: 2,
          name: 'João',
          score: 5,
          distance: '500m',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 100,
        },
        {
          id: 10,
          name: 'Carlos',
          score: 4.7,
          distance: '1km',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 110,
        },
        {
          id: 132,
          name: 'Matheus',
          score: 4.7,
          distance: '5km',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 100,
        },
        {
          id: 1211,
          name: 'Alexandre',
          score: 5,
          distance: '9km',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental. texto um pouco mais longo para quebrar a linha e ficar um pouco maior',
          price: 100,
        },
        {
          id: 51,
          name: 'Rui',
          score: 5,
          distance: '10km',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 100,
        },
        {
          id: 54,
          name: 'Marcela',
          score: 5,
          distance: '11km',
          shortDescription:
            'Professor de química há 8 anos formado pela PUC Minas e com experiência em laboratório e escolas de ensino fundamental.',
          price: 100,
        },
      ],
      total: 40,
    }
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
}
