import { Counter } from './components/Counter'
import { FetchData } from './components/FetchData'
import { Home } from './pages/Home'
import { Subscribe } from './pages/Subscribe'
import Login from './pages/Login'
import { SearchResults } from './pages/SearchResults'

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/subscribe',
    element: <Subscribe />,
  },
  {
    path: '/login',
    element: <Login />,
  },
  {
    path: '/counter',
    element: <Counter />,
  },
  {
    path: '/fetch-data',
    element: <FetchData />,
  },
  {
    path: '/results',
    element: <SearchResults />,
  },
]

export default AppRoutes
